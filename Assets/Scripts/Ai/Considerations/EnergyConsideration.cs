using UnityEngine;

namespace Ai.Considerations
{
    [CreateAssetMenu(menuName = "StaticData/Considerations/Energy", fileName = "EnergyConsideration")]
    public class EnergyConsideration : AiConsideration
    {
        public override float ScoreConsideration(AiController ai)
        {
            return 0;
        }
    }
}