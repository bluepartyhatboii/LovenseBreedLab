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

            original = AccessTools.Method(typeof(OctoControl), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(CurScGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(CurScGallery), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(EnemyController), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(EnemyController), "Rest");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(FlyTrapControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(FlyTrapControl), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(FutaGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(FutaGallery), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(FutaMounter), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(FutaMounter), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(HoundControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(HoundControl), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(HoundGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(HoundGallery), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(HuggerControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(HuggerControl), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(HuggerGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(HuggerGallery), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(HumanoidController), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(HumanoidController), "ThrustEventHard");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(HumanoidController), "Rest");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(ImpregInsectControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(ImpregInsectControl), "Rest");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(ImpregnatorGallary), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(ImpregnatorGallary), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(LickerController), "ThrustEvent");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(LickerController), "Rest");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(LickerGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(LickerGallery), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

          //  original = AccessTools.Method(typeof(), "ThrustEvent");
          //  postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
          //  harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(LurkerGallery), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(MantisAi), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(MantisAi), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(MantisGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(MantisGallery), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(MindFleyerControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(MindFleyerControl), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(NewEnemControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(NewEnemControl), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(NewLickerControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(NewLickerControl), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(OctoGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(OctoGallery), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(PlantWalkerControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(PlantWalkerControl), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(PWalkerGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(PWalkerGallery), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(ScientistNewControl), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(ScientistNewControl), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(WaspControl), "VagEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(WaspControl), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(WaspGallery), "VagEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(WaspGallery), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            /******************************************************************************************/

            original = AccessTools.Method(typeof(WolfGallery), "ThrustEvent");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(WolfGallery), "ThrustEventHard");
            postfix = AccessTools.Method(typeof(ThrustPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(WolfGallery), "Release");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(RestPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            /******************************************************************************************/
            /*
            original = AccessTools.Method(typeof(WolfTakeMe), "ThrustEvent");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(WolfTakeMe), "ThrustHardEvent");
            postfix = AccessTools.Method(typeof(RestPatcher), nameof(ThrustPatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));

            original = AccessTools.Method(typeof(WolfTakeMe), "Update");
            postfix = AccessTools.Method(typeof(UpdatePatcher), nameof(UpdatePatcher.Postfix));
            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
            */


        }
    }
}
