using Components;
using Lekret.Ecs;
using UnityEngine;

namespace Ai.Considerations
{
    [CreateAssetMenu(menuName = "StaticData/Considerations/Money", fileName = "MoneyConsideration")]
    public class MoneyConsideration : AiConsideration
    {
        public int MaxMoney;
        public AnimationCurve ResponseCurve;
        
        public override float EvaluateScore(Entity entity)
        {
            if (entity.TryGet(out AiStats stats))
            {
                return ResponseCurve.Evaluate((float) stats.Money / MaxMoney);
            }
            return 0;
        }
    }
}