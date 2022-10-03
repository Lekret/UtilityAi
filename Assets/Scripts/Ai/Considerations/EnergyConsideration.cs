using UnityEngine;

namespace Ai.Considerations
{
    [CreateAssetMenu(menuName = "StaticData/Considerations/Energy", fileName = "EnergyConsideration")]
    public class EnergyConsideration : AiConsideration
    {
        public override float EvaluateScore(AiEntity entity)
        {
            return 0f;
        }
    }
}