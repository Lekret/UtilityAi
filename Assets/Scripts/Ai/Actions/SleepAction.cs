using System.Collections;
using Environment;
using UnityEngine;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Sleep", fileName = "SleepAction")]
    public class SleepAction : AiAction
    {
        public override void Execute(AiEntity entity)
        {
            entity.StartCoroutine(SleepForTime(entity, 3));
        }
        
        private static IEnumerator SleepForTime(AiEntity entity, float time)
        {
            var house = FindObjectOfType<House>();
            entity.NavMeshAgent.SetDestination(house.transform.position);
            
            while (entity.NavMeshAgent.remainingDistance > Vector3.kEpsilon)
            {
                yield return null;
            }

            yield return new WaitForSeconds(time);

            Debug.Log("Sleep completed");
            entity.OnFinishedAction();
        }
    }
}