using System.Collections;
using Environment;
using Infrastructure;
using UnityEngine;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Sleep", fileName = "SleepAction")]
    public class SleepAction : AiAction
    {
        public float SleepTime;
        public int EnergyGain;
        
        private Location _location;

        public override void Init()
        {
            _location = Services.Get<Location>();
        }

        public override void Execute(AiEntity entity)
        {
            entity.StartCoroutine(Sleep(entity));
        }
        
        private IEnumerator Sleep(AiEntity entity)
        {
            entity.NavMeshAgent.SetDestination(_location.House.transform.position);
            yield return null;
            
            while (entity.NavMeshAgent.remainingDistance > Vector3.kEpsilon)
            {
                yield return null;
            }

            yield return new WaitForSeconds(SleepTime);
            entity.Stats.ChangeEnergy(EnergyGain);
            entity.OnFinishedAction();
        }
    }
}