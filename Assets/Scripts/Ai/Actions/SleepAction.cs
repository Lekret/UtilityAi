using System.Collections;
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
        
        private IEnumerator SleepForTime(AiEntity entity, float time)
        {
            Debug.Log("Sleep started");
        
            var counter = time;
            while (counter > 0)
            {
                counter -= Time.deltaTime;
                yield return null;
            }

            Debug.Log("Sleep completed");
            entity.OnFinishedAction();
        }
    }
}