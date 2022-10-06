using UnityEngine;

namespace Ai.Considerations
{
    [CreateAssetMenu(menuName = "StaticData/Considerations/Money", fileName = "MoneyConsideration")]
    public class MoneyConsideration : AiConsideration
    {
        public int MaxMoney;
        public AnimationCurve ResponseCurve;
        
        public override float EvaluateScore(AiEntity entity)
        {
            return ResponseCurve.Evaluate((float) entity.Stats.Money / MaxMoney);
        }
    }
}