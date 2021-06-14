using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace OdinBlckPhntmUnlock
{
    [BepInPlugin("_BlckPnthm_Unlock", "BlckPnthm_Unlock", "1.0.0.0")]
    public class BlckPnthm : BaseUnityPlugin
    {
        public const string MODNAME = "_BlckPnthm_Unlock";
        public const string AUTHOR = "BlckPhntmEdits";
        public const string GUID = "BlckPnthm_Unlock";

        public const string VERSION = "1.0.0.0";
        internal readonly ManualLogSource log;
        internal readonly Harmony harmony;
        internal readonly Assembly assembly;
        public readonly string modFolder;

        public BlckPnthm()
        {
            log = base.Logger;
            harmony = new Harmony("_DLC_Unlock");
            assembly = Assembly.GetExecutingAssembly();
            modFolder = Path.GetDirectoryName(assembly.Location);
        }

        public void Start()
        {
            harmony.PatchAll(assembly);
        }

    }

    [HarmonyPatch(typeof(DLCMan), "IsDLCInstalled", new Type[]
       {
    typeof(DLCMan.DLCInfo)})]
    public static class Patches
    {
        private static bool Prefix(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}
