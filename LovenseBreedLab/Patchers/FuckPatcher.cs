using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreederLaboratoryLovesense.Patchers
{
    public class FuckPatcher
    {
        public delegate void OnFuckHandler();

        public static event OnFuckHandler onFuckHandler;
        public static void Postfix()
        {
            onFuckHandler?.Invoke();
        }
    }
}
