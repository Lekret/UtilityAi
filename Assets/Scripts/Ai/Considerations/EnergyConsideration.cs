using Components;
using Lekret.Ecs;
using UnityEngine;

namespace Ai.Considerations
{
    [CreateAssetMenu(menuName = "StaticData/Considerations/Energy", fileName = "EnergyConsideration")]
    public class EnergyConsideration : AiConsideration
    {
        public AnimationCurve ResponseCurve;
        
        public override float EvaluateScore(Entity entity)
        {
            if (entity.TryGet(out AiStats stats))
            {
                return ResponseCurve.Evaluate((float) stats.Energy / stats.MaxEnergy);
            }
            return 0;
        }
    }
}