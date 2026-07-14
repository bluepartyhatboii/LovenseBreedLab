using BreederLaboratoryLovesense.Patchers;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BreederLaboratorySexMachine.Patchers
{
    public class BreederModPatcher
    {
        public BreederModPatcher()
        {
            var harmony = new Harmony("LoveSenseSexMachineMod");

            var original = AccessTools.Method(typeof(OctoControl), "ThrustEvent");
            var postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(EnemyController), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(FlyTrapControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(FutaGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(FutaMounter), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(HoundControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(HoundGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(HuggerControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(HuggerGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(HumanoidController), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(HumanoidController), "ThrustEventHard");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(ImpregInsectControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(ImpregnatorGallary), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(LickerController), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(LickerGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(MantisAi), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(MantisGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(MindFleyerControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(NewEnemControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(NewLickerControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(OctoGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(PlantWalkerControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(PWalkerGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(ScientistNewControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(WaspControl), "VagEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(WaspGallery), "VagEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(WolfGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(WolfGallery), "ThrustEventHard");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/
            
            original = AccessTools.Method(typeof(WolfTakeMe), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(WolfTakeMe), "ThrustEventHard");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(CurScGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(CurScGallery), "ThrustEventHard");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(HumJustFuck), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(HumJustFuck), "ThrustEventHard");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/

            original = AccessTools.Method(typeof(PhantomHugger), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(TentacleThrustEvent), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(LurkerGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(TentButtom), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(TentacleGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

        }
    }
}
