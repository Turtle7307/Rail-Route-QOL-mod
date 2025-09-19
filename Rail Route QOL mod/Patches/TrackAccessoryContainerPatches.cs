using System.Linq;
using Game.Building.RoutingSensor;
using Game.Building.ShuntingSensor;
using Game.Railroad;
using Game.Railroad.Sensor;
using Game.Train;
using HarmonyLib;
using Rail_Route_QOL_mod.Coroutines;
using UnityEngine;

namespace Rail_Route_QOL_mod.Patches
{
    [HarmonyPatch(typeof(TrackAccessoryContainer))]
    internal static class TrackAccessoryContainerPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(TrackAccessoryContainer.TriggerDepartureAutomation))]
        public static void Postfix(TrackAccessoryContainer __instance, Train train)
        {
            if (train.OperationMode == OperationMode.Shunting)
                return;

            // Arrival Sensor on Station
            if (__instance.TrackAccessories.OfType<ArrivalSensor>().Any())
                __instance.TrackAccessories.OfType<ArrivalSensor>().First().TriggerContactAutomation(train);
            
            // Shunting Sensor on Station
            if (!__instance.TrackAccessories.OfType<ShuntingSensor>().Any() || !__instance.TrackAccessories.OfType<RoutingSensor>().Any()) return;
            var shuntingSensor = __instance.TrackAccessories.OfType<ShuntingSensor>().First();
            var routingSensor = __instance.TrackAccessories.OfType<RoutingSensor>().First();

            if (!train.ReverseOnceStopped && !train.StopAndReverse && !shuntingSensor.IsTrainEligible(train)) return;

            var gameObject = new GameObject();
            var delayed = gameObject.AddComponent<DelayedShuntingSensorCoroutine>();
            delayed.StartCoroutine(train, shuntingSensor, routingSensor);
        }
    }
}