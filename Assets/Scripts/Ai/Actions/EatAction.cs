using System.Collections;
using Environment;
using Infrastructure;
using UnityEngine;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Eat", fileName = "EatAction")]
    public class EatAction : AiAction
    {
        public float EatTime;
        public int SatietyGain;

        private Location _location;

        public override void Init()
        {
            _location = Services.Get<Location>();
        }

        public override void Execute(AiEntity entity)
        {
            entity.StartCoroutine(Eat(entity));
        }
        
        private IEnumerator Eat(AiEntity entity)
        {
            entity.NavMeshAgent.SetDestination(_location.Food.transform.position);
            yield return null;
            
            while (entity.NavMeshAgent.remainingDistance > Vector3.kEpsilon)
            {
                yield return null;
            }

            yield return new WaitForSeconds(EatTime);
            entity.Stats.ChangeSatiety(SatietyGain);
            entity.OnFinishedAction();
        }
    }
}