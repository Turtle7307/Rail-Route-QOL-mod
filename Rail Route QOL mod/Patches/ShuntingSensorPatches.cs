using Game.Building.ShuntingSensor;
using HarmonyLib;

namespace Rail_Route_QOL_mod.Patches
{
    [HarmonyPatch(typeof(ShuntingSensor))]
    internal static class ShuntingSensorPatches
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(ShuntingSensor.TriggerArrivalAutomation))]
        public static bool Prefix()
        {
            return false; //skip original
        }
    }
}