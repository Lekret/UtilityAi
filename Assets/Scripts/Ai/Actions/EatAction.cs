using UnityEngine;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Eat", fileName = "EatAction")]
    public class EatAction : AiAction
    {
        public override void Execute(AiController ai)
        {
            Debug.Log("I ate food");
            ai.OnFinishedAction();
        }
    }
}