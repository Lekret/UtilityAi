using System.Collections;
using Environment;
using UnityEngine;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Work", fileName = "WorkAction")]
    public class WorkAction : AiAction
    {
        public override void Execute(AiEntity entity)
        {
            entity.StartCoroutine(WorkForTime(entity, 2));
        }
        
        private static IEnumerator WorkForTime(AiEntity entity, float time)
        {
            var house = FindObjectOfType<Wood>();
            entity.NavMeshAgent.SetDestination(house.transform.position);
            
            while (entity.NavMeshAgent.remainingDistance > Vector3.kEpsilon)
            {
                yield return null;
            }

            yield return new WaitForSeconds(time);

            Debug.Log("Work completed");
            entity.OnFinishedAction();
        }
    }
}