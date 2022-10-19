using Components;
using Lekret.Ecs;
using UnityEngine;

namespace Ai.Considerations
{
    [CreateAssetMenu(menuName = "StaticData/Considerations/Hunger", fileName = "HungerConsideration")]
    public class SatietyConsideration : AiConsideration
    {
        public AnimationCurve ResponseCurve;
        
        public override float EvaluateScore(Entity entity)
        {
            if (entity.TryGet(out AiStats stats))
            {
                return ResponseCurve.Evaluate((float) stats.Satiety / stats.MaxSatiety);
            }
            return 0;
        }
    }
}