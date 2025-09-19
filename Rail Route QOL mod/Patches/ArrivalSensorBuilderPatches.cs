using Game.Building.Sensor;
using HarmonyLib;

namespace Rail_Route_QOL_mod.Patches
{
    [HarmonyPatch(typeof(ArrivalSensorBuilder))]
    internal class ArrivalSensorBuilderPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch("get_BuildableInStation")]
        public static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }
}