using UnityEngine;

namespace Ai.Considerations
{
    [CreateAssetMenu(menuName = "StaticData/Considerations/Energy", fileName = "EnergyConsideration")]
    public class EnergyConsideration : AiConsideration
    {
        public AnimationCurve ResponseCurve;
        
        public override float EvaluateScore(AiEntity entity)
        {
            return ResponseCurve.Evaluate((float) entity.Stats.Energy / entity.Stats.MaxEnergy);
        }
    }
}