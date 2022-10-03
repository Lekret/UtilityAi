using System.Collections;
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
        
        private IEnumerator WorkForTime(AiEntity entity, float time)
        {
            Debug.Log("Mining started");
        
            var counter = time;
            while (counter > 0)
            {
                counter -= Time.deltaTime;
                yield return null;
            }

            Debug.Log("Mining completed");
            entity.OnFinishedAction();
        }
    }
}