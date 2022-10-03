using UnityEngine;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Eat", fileName = "EatAction")]
    public class EatAction : AiAction
    {
        public override void Execute(AiEntity entity)
        {
            Debug.Log("I ate food");
            entity.OnFinishedAction();
        }
    }
}