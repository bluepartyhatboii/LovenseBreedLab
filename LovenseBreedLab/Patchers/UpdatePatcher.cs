using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreederLaboratoryLovesense.Patchers
{
    public class UpdatePatcher
    {
        public delegate void OnUpdateHandler();

        public static event OnUpdateHandler onUpdateHandler;
        public static void Postfix()
        {
            onUpdateHandler?.Invoke();
        }
    }
}
