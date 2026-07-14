using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreederLaboratoryLovesense.Patchers
{
    public class RestPatcher
    {
        public delegate void OnRestHandler();

        public static event OnRestHandler onRestHandler;
        public static void Postfix()
        {
            onRestHandler?.Invoke();
        }
    }
}
