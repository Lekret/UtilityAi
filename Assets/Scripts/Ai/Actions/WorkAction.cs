using System.Collections;
using Environment;
using Infrastructure;
using UnityEngine;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Work", fileName = "WorkAction")]
    public class WorkAction : AiAction
    {
        public float WorkTime;
        public int MoneyGain;
        
        private Location _location;

        public override void Init()
        {
            _location = Services.Get<Location>();
        }

        public override void Execute(AiEntity entity)
        {
            entity.StartCoroutine(Work(entity));
        }
        
        private IEnumerator Work(AiEntity entity)
        {
            entity.NavMeshAgent.SetDestination(_location.Wood.transform.position);
            yield return null;
            
            while (entity.NavMeshAgent.remainingDistance > Vector3.kEpsilon)
            {
                yield return null;
            }

            yield return new WaitForSeconds(WorkTime);
            entity.Stats.ChangeMoney(MoneyGain);
            entity.OnFinishedAction();
        }
    }
}