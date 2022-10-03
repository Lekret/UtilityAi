using UnityEngine;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Work", fileName = "WorkAction")]
    public class WorkAction : AiAction
    {
        public override void Execute(AiController ai)
        {
            ai.Work(3);
        }
    }
}