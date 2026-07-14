
using BepInEx;
using BreederLaboratoryLovesense.LovesenseSDK;
using BreederLaboratoryLovesense.Patchers;
using BreederLaboratorySexMachine.Patchers;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using System.Threading;

namespace BreederLaboratoryLovesense
{
    [BepInPlugin("LoveSenseSexMachineMod", "LoveSenseSexMachineMod", "1.0.0")]
    public class BreederMod : BaseUnityPlugin
    {

        private string _id = "";
        HeroineStats playerStats;
        PlayerController playerController;
        bool sexStarted;

        Dictionary<string, Dictionary<int, int>> sexTime;
        List<Timer> sexTimers;

        //xmachine duty cycle data:
        //1: 1165ms
        //2: 987ms
        //3: 820ms
        //10: 395 ms
        //15: 300ms
        //20: 194ms

        //monsters raw data, each thrust interval, seperated by "," if the interval changes, ex. hugger thrusts every 625ms, after 31seconds into the scene, it thrusts every 417ms
        //hugger: 625, 31 417
        //facehugger: 1.2sec
        //wolf feral: 583, 6 417, -20ms per thrust, until 236
        //wasp: 791, 26 396
        //fytrap: 583, 15 416, 21 291
        //licker: 542, 14 387, 19.6 271
        //snake: 1208, 20 863, 26 604, 31 200
        //mantis: 792, 10 560, 16.7 377, 19.6 250
        //wolf t1: 584, 14.4 267 20.5 188
        //futa: 583, 15 396
        //plantwalker: 584
        //mindfleyer: 792, 31.6 1625, 132 792

        //formula ms to xmachine speed setting
        // duty cycle = (1160 / (speed^0.62)) + 80

        void Awake()
        {
            sexTimers = new List<Timer>();


            PopulateSexTime();

            GetSupportedCommand();

            ThrustPatcher.onThrustHandler += OnThrustEvent;
            FuckPatcher.onFuckHandler += OnFuckStarted;
            RestPatcher.onRestHandler += OnFuckEnd;

            new BreederModPatcher();
           
            LovenseBLETools.GetInstance().InitCallback();
            LovenseBLETools.GetInstance().CheckBLEStatus();

            LovenseBLETools.GetInstance().lovenseNotifyEvent += LovenseNotifyMessage;
            LovenseBLETools.GetInstance().addToyEvent += LovenseAddToyEvent;
            LovenseBLETools.GetInstance().connectChangeEvent += LoveSenseConnectChangeEvent;

            LovenseBLETools.GetInstance().StartBLEScan();
            Logger.LogInfo("LoveSenseSexMachineMod Initialized");
        }

        private void OnThrustEvent()
        {
            long ms = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Logger.LogInfo("Thurst event at: " + ms);
            while(playerStats == null)
            {
                playerStats = UnityEngine.Object.FindObjectOfType<HeroineStats>();
            }
            while(playerController == null)
            {
                playerController = UnityEngine.Object.FindObjectOfType<PlayerController>();
            }
            if (!sexStarted)
            {
                sexStarted = true;
                OnFuckStarted();
            }
        }
        
        private void OnFuckStarted()
        {
            long ms = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Logger.LogInfo("Sex scene begin at: " + ms);
            Logger.LogInfo("Found player");

            StartSexTimers();
        }

        private void StartSexTimers()
        {
            Logger.LogInfo("partner:" + playerStats.mySexPartner);
            Logger.LogInfo("focus: " + playerController.focus);
            if ((playerStats.mySexPartner != null) || (playerController.focus != null))
            {
                try
                {

                    Dictionary<int, int> timestamps = FindTimestamps();
                    Logger.LogInfo("Speed change timestamps: ");

                    foreach (KeyValuePair<int, int> item in timestamps)
                    {
                        int key = item.Key;
                        int value = item.Value;

                        Logger.LogInfo("+" + key + "ms -- speed " + value);

                        Timer sexTimer = new Timer(_2 =>
                        {
                            SendStartCommand(value);
                        }, null, key, Timeout.Infinite);

                        sexTimers.Add(sexTimer);
                    }
                }
                catch(Exception e)
                {
                    Logger.LogInfo(e.Message);
                }
                
            }
        }

        private void SendStartCommand(int speed)
        {
#if SLOW
            speed = speed >= 2 ? speed / 2 : speed;
#elif SLOWER
            speed = speed >= 4 ? speed / 4 : speed;
#endif

            List<LovenseCommand> commands = new List<LovenseCommand>();

            Logger.LogInfo("BLE changing speed to: " + speed);

            LovenseCommand addCommand = new LovenseCommand();
            addCommand.commandType = LovenseCommandType.VIBRATE;
            addCommand.value = speed;
            commands.Add(addCommand);

            addCommand = new LovenseCommand();
            addCommand.commandType = LovenseCommandType.THRUSTRING;
            addCommand.value = speed;
            commands.Add(addCommand);

            LovenseBLETools.GetInstance().SendCommands(_id, commands.ToArray());
        }

        private void OnFuckEnd()
        {
            long ms = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Logger.LogInfo("Sex scene end at: " + ms);

            sexStarted = false;

            foreach(Timer timer in sexTimers)
            {
                timer.Dispose();
            }
            sexTimers.Clear();

            List<LovenseCommand> commands = new List<LovenseCommand>();

            LovenseCommand addCommand = new LovenseCommand();
            addCommand.commandType = LovenseCommandType.VIBRATE;
            addCommand.value = 0;
            commands.Add(addCommand);

            addCommand = new LovenseCommand();
            addCommand.commandType = LovenseCommandType.THRUSTRING;
            addCommand.value = 0;
            commands.Add(addCommand);

            LovenseBLETools.GetInstance().SendCommands(_id, commands.ToArray());
        }

        private void OnLog(string log)
        {
            Logger.LogInfo(log);
        }

        private void LovenseAddToyEvent(LovenseToy toy)
        {
            Logger.LogInfo("BLE item found, connecting...");
            LovenseBLETools.GetInstance().StopBLEScan();
            LovenseBLETools.GetInstance().ConnectToy(toy.id);
        }
        private void LovenseNotifyMessage(LovenseNotifyType type, string id)
        {
            //Logger.LogInfo("Notify tpye: " + type + " id: " + id);
        }

        private void LoveSenseConnectChangeEvent(string id, bool connected)
        {
            if(!connected)
            {
                _id = "";
                Logger.LogInfo("BLE lost connection, trying to reconnect...");
                LovenseBLETools.GetInstance().StartBLEScan();
            }
            else
            {
                _id = id;
                Logger.LogInfo("BLE Connection success");
            }
        }

        void OnApplicationQuit()
        {
            Logger.LogInfo("Disconnecting BLE...");
            LovenseBLETools.GetInstance().DisConnectToy(_id);
        }

        private void PopulateSexTime()
        {
            sexTime = new Dictionary<string, Dictionary<int, int>>();

            Dictionary<int, int> sexTimestamp;

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 3);
            sexTimestamp.Add(31000, 7);
            sexTime.Add("hugger", sexTimestamp);

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 1);
            sexTime.Add("facehugger", sexTimestamp);

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 4);
            sexTimestamp.Add(6000, 7);
            sexTimestamp.Add(6200, 8);
            sexTimestamp.Add(6400, 9);
            sexTimestamp.Add(6600, 10);
            sexTimestamp.Add(6800, 12);
            sexTimestamp.Add(7000, 15);
            sexTimestamp.Add(7200, 18);
            sexTimestamp.Add(7400, 22);
            sexTimestamp.Add(7600, 25);
            sexTime.Add("wolfFeral", sexTimestamp);

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 2);
            sexTimestamp.Add(26000, 8);
            sexTime.Add("wasp", sexTimestamp);

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 3);
            sexTimestamp.Add(15000, 7);
            sexTimestamp.Add(21000, 14);
            sexTime.Add("flyTrap", sexTimestamp);

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 4);
            sexTimestamp.Add(14000, 8);
            sexTimestamp.Add(19600, 17);
            sexTime.Add("licker", sexTimestamp);

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 1);
            sexTimestamp.Add(20000, 2);
            sexTimestamp.Add(26000, 3);
            sexTimestamp.Add(31000, 40);
            sexTime.Add("snake", sexTimestamp);

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 3);
            sexTimestamp.Add(14400, 17);
            sexTimestamp.Add(20500, 40);
            sexTime.Add("wolfT1", sexTimestamp);

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 3);
            sexTimestamp.Add(15000, 7);
            sexTime.Add("futa", sexTimestamp);

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 3);
            sexTime.Add("plantWalker", sexTimestamp);

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 2);
            sexTimestamp.Add(31600, 1);
            sexTimestamp.Add(132000, 2);
            sexTime.Add("mindFleyer", sexTimestamp);

            sexTimestamp = new Dictionary<int, int>();
            sexTimestamp.Add(0, 2);
            sexTimestamp.Add(10000, 4);
            sexTimestamp.Add(16700, 9);
            sexTimestamp.Add(19600, 22);
            sexTime.Add("mantis", sexTimestamp);

        }

        private Dictionary<int,int> FindTimestamps()
        {
            OctoControl octo = playerStats.mySexPartner?.GetComponent<OctoControl>();
            if (octo != null)
            {
                Logger.LogInfo("Found partner t1hugger");
                return sexTime["facehugger"];
            }

            OctoControl octog = playerController.focus?.GetComponent<OctoControl>();
            if (octog != null)
            {
                Logger.LogInfo("Found partner t1hugger gallery");
                return sexTime["facehugger"];
            }

            /*******************************************************************************************/
            HuggerControl hugger = playerStats.mySexPartner?.GetComponent<HuggerControl>();
            if (hugger != null)
            {
                Logger.LogInfo("Found partner facehugger");
                return sexTime["hugger"];
            }

            HuggerControl huggerg = playerController.focus?.GetComponent<HuggerControl>();
            if (huggerg != null)
            {
                Logger.LogInfo("Found partner facehugger gallery");
                return sexTime["hugger"];
            }
            /*******************************************************************************************/
            HoundControl hound = playerStats.mySexPartner?.GetComponent<HoundControl>();
            if (hound != null)
            {
                Logger.LogInfo("Found partner t4 wolf");
                return sexTime["wolfFeral"];
            }

            HoundGallery houndg = playerController.focus?.GetComponent<HoundGallery>();
            if (houndg != null)
            {
                Logger.LogInfo("Found partner t4 wolf gallery");
                return sexTime["wolfFeral"];
            }
            /*******************************************************************************************/
            WaspControl wasp = playerStats.mySexPartner?.GetComponent<WaspControl>();
            if (wasp != null)
            {
                Logger.LogInfo("Found partner wasp");
                return sexTime["wasp"];
            }

            WaspGallery waspg = playerController.focus?.GetComponent<WaspGallery>();
            if (waspg != null)
            {
                Logger.LogInfo("Found partner wasp gallery");
                return sexTime["wasp"];
            }
            /*******************************************************************************************/
            ImpregInsectControl flytrap = playerStats.mySexPartner?.GetComponent<ImpregInsectControl>();
            if (flytrap != null)
            {
                Logger.LogInfo("Found partner t1 flying insect gallery");
                return sexTime["flytrap"];
            }

            ImpregnatorGallary flytrapg = playerController.focus?.GetComponent<ImpregnatorGallary>();
            if (flytrapg != null)
            {
                Logger.LogInfo("Found partner t1 flying insect gallery");
                return sexTime["flyTrap"];
            }
            /*******************************************************************************************/
            LickerController licker = playerStats.mySexPartner?.GetComponent<LickerController>();
            if (licker != null)
            {
                Logger.LogInfo("Found partner licker");
                return sexTime["licker"];
            }

            LickerGallery lickerg = playerController.focus?.GetComponent<LickerGallery>();
            if (lickerg != null)
            {
                Logger.LogInfo("Found partner licker gallery");
                return sexTime["licker"];
            }
            /*******************************************************************************************/
            LurkerGallery lurkerg = playerController.focus?.GetComponent<LurkerGallery>();
            if (lurkerg != null)
            {
                Logger.LogInfo("lurkerg");
                return sexTime["snake"];
            }
            /*******************************************************************************************/
            MantisAi mantis = playerStats.mySexPartner?.GetComponent<MantisAi>();
            if (hugger != null)
            {
                Logger.LogInfo("Found partner mantis");
                return sexTime["mantis"];
            }

            MantisGallery mantisg = playerController.focus?.GetComponent<MantisGallery>();
            if (mantisg != null)
            {
                Logger.LogInfo("Found partner mantis gallery");
                return sexTime["mantis"];
            }
            /*******************************************************************************************/
            WolfGallery wolfg = playerController.focus?.GetComponent<WolfGallery>();
            if (wolfg != null)
            {
                Logger.LogInfo("Found partner T1 wolf gallery");
                return sexTime["wolfT1"];
            }

            /*******************************************************************************************/
            FutaMounter futa = playerStats.mySexPartner?.GetComponent<FutaMounter>();
            if (futa != null)
            {
                Logger.LogInfo("Found partner futa");
                return sexTime["futa"];
            }

            FutaGallery futag = playerController.focus?.GetComponent<FutaGallery>();
            if (futag != null)
            {
                Logger.LogInfo("Found partner futa gallery");
                return sexTime["futa"];
            }
            /*******************************************************************************************/
            PlantWalkerControl plantWalker = playerStats.mySexPartner?.GetComponent<PlantWalkerControl>();
            if (plantWalker != null)
            {
                Logger.LogInfo("Found partner plant walker");
                return sexTime["plantWalker"];
            }

            /*******************************************************************************************/
            MindFleyerControl mindFleyer = playerStats. mySexPartner?.GetComponent<MindFleyerControl>();
            if (mindFleyer != null)
            {
                Logger.LogInfo("Found partner mind fleyer");
                return sexTime["mindFleyer"];
            }

            //Default if anything not found(for debug really)
            Dictionary<int, int>  timestamp = new Dictionary<int, int>();

            timestamp.Add(0, 1);

            Logger.LogInfo("No partner found");

            return timestamp;
        }


        public void GetSupportedCommand()
        {
            string supportText = @",symbol,type,showName,func
0,1.5,version,,
1,[  ""l""],Ambi,Ambi,""{ """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}
            ""
2,[  ""ca""],Mission2,Mission2,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
3,[  ""su""],c20,C20,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
4,[  ""t""],Calor,Calor,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
5,[  ""r""],Diamo,Diamo,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
6,[  ""j""],Dolce,Dolce,""{  """"p"""": false,  """"r"""": false,  """"v2"""": true,  """"v1"""": true,  """"v"""": true}""
7,[  ""w""],Domi,Domi,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
8,[  ""p""],Edge,Edge,""{  """"p"""": false,  """"r"""": false,  """"v2"""": true,  """"v1"""": true,  """"v"""": true}""
9,[  ""ef""],Exomoon,Exomoon,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
10,[  ""x""],Ferri,Ferri,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
11,[  ""ei""],Flexer,Flexer,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true,  """"f"""": true}""
12,[  ""n""],Gemini,Gemini,""{  """"p"""": false,  """"r"""": false,  """"v2"""": true,  """"v1"""": true,  """"v"""": true}""
13,[  ""ea""],Gravity,Gravity,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true,  """"t"""": true,  """"s"""": false}""
14,[  ""ed""],Gush,Gush,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
15,[  ""ba""],SolacePro,SolacePro,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": false,  """"t"""": true,  """"pos"""": true}""
16,[  ""z""],Hush,Hush,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
17,[  ""eb""],Hyphy,Hyphy,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
18,[  ""u""],Lapis,Lapis,""{  """"p"""": false,  """"r"""": false,  """"v2"""": true,  """"v1"""": true,  """"v3"""": true,  """"v"""": true}""
19,[  ""s""],Lush,Lush,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
20,""[  """"toyb"""",  """"b""""]"",Max,Max,""{  """"p"""": true,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
21,[  ""fs""],MiniXMachine,MiniXMachine,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true,  """"t"""": true}""
22,[  ""v""],Mission,Mission,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
23,""[  """"toyc"""",  """"toya"""",  """"c"""",  """"a""""]"",Nora,Nora,""{  """"p"""": false,  """"r"""": true,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
24,[  ""o""],Osci,Osci,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
25,[  ""qa""],QA01,QA01,""{  """"p"""": false,  """"r"""": false,  """"v2"""": true,  """"v1"""": true,  """"v"""": true}""
26,[  ""el""],Ridge,Ridge,""{  """"p"""": false,  """"r"""": true,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
27,[  ""h""],Solace,Solace,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": false,  """"t"""": true,  """"d"""": true}""
28,[  ""q""],Tenera,Tenera,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true,  """"s"""": true}""
29,[  ""sd""],Vulse,Vulse,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true}""
30,[  ""f""],XMachine,XMachine,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": true,  """"t"""": true}""
31,[  ""ez""],Gush2,Gush2,""{  """"p"""": false,  """"r"""": false,  """"v2"""": false,  """"v1"""": false,  """"v"""": false, """"o"""":true}""";

            //string url = "https://developer.lovense.com/LovenseToySupportConfig.csv";
            //HttpClient client = new HttpClient();
            //string supportText = await client.GetStringAsync(new Uri(url));

            LovenseBLETools.GetInstance().InitSupport(supportText, (InitSupportCommandStatus status) =>
           {
                if (status == InitSupportCommandStatus.SUCCESS)
                {
                    Logger.LogInfo("BLE init success");
                }
                else
                {
                   Logger.LogInfo("BLE init error");
                }
            });
        }
    }
}
