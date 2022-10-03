using UnityEngine;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Sleep", fileName = "SleepAction")]
    public class SleepAction : AiAction
    {
        public override void Execute(AiController ai)
        {
            ai.Sleep(3);
        }
    }
}