using System.Collections;
using System.Linq;
using Game.Building.RoutingSensor;
using Game.Building.ShuntingSensor;
using Game.Context;
using Game.Train;
using UnityEngine;

namespace Rail_Route_QOL_mod.Coroutines
{
    internal class DelayedShuntingSensorCoroutine : MonoBehaviour
    {
        private ShuntingSensor _shuntingSensor;
        private RoutingSensor _routingSensor;
        private Train _train;
        
        public void StartCoroutine(Train train, ShuntingSensor shuntingSensor, RoutingSensor routingSensor)
        {
            _train = train;
            _shuntingSensor = shuntingSensor;
            _routingSensor = routingSensor;
            StartCoroutine(Coroutine());
        }

        IEnumerator Coroutine()
        {
            while (!_shuntingSensor.IsTrainEligible(_train))
            {
                if (!_train.ReverseOnceStopped && !_train.StopAndReverse && !_shuntingSensor.IsTrainEligible(_train))
                    yield break;
                yield return null;
            }

            var semaphore = _routingSensor.Semaphores.First(s => _train.HeadsTowards.Equals(s));
            Ctx.Deps.RoutingController.DeletePathFromSemaphore(semaphore);
            _shuntingSensor.TriggerContactAutomation(_train);
        }
    }
}