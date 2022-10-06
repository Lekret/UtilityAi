using UnityEngine;

namespace Ai.Considerations
{
    [CreateAssetMenu(menuName = "StaticData/Considerations/Hunger", fileName = "HungerConsideration")]
    public class SatietyConsideration : AiConsideration
    {
        public AnimationCurve ResponseCurve;
        
        public override float EvaluateScore(AiEntity entity)
        {
            return ResponseCurve.Evaluate((float) entity.Stats.Satiety / entity.Stats.MaxSatiety);
        }
    }
}