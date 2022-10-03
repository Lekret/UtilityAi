using UnityEngine;

namespace Ai.Considerations
{
    [CreateAssetMenu(menuName = "StaticData/Considerations/Money", fileName = "MoneyConsideration")]
    public class MoneyConsideration : AiConsideration
    {
        public override float ScoreConsideration(AiController ai)
        {
            return 0.9f;
        }
    }
}