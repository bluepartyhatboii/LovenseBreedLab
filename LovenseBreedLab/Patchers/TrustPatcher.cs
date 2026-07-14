using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreederLaboratoryLovesense.Patchers
{
    public class ThrustPatcher
    {
        public delegate void OnThrustHandler();

        public static event OnThrustHandler onThrustHandler;
        public static void Postfix()
        {
            onThrustHandler?.Invoke();
        }
    }
}
