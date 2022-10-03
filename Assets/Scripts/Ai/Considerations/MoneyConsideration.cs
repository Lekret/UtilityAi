using UnityEngine;

namespace Ai.Considerations
{
    [CreateAssetMenu(menuName = "StaticData/Considerations/Money", fileName = "MoneyConsideration")]
    public class MoneyConsideration : AiConsideration
    {
        public override float EvaluateScore(AiEntity entity)
        {
            return 0f;
        }
    }
}