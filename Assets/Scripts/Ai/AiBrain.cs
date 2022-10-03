using UnityEngine;

namespace Ai
{
    public class AiBrain : MonoBehaviour
    {
        [SerializeField] private AiController _controller;
        
        public AiAction BestAction { get; private set; }
        public bool FoundBestAction { get; set; }

        private void Update()
        {
            if (BestAction == null)
            {
                UpdateBestAction(_controller, _controller.Actions);
            }
        }

        public void UpdateBestAction(AiController ai, AiAction[] actions)
        {
            var bestScore = 0f;
            var bestActionIdx = 0;
            for (var i = 0; i < actions.Length; i++)
            {
                if (ScoreAction(ai, actions[i]) > bestScore)
                {
                    bestActionIdx = i;
                    bestScore = actions[i].Score;
                }
            }

            BestAction = actions[bestActionIdx];
            FoundBestAction = true;
        }

        private float ScoreAction(AiController ai, AiAction action)
        {
            var score = 1f;
            foreach (var consideration in action.Considerations)
            {
                var considerationScore = consideration.ScoreConsideration(ai);
                score *= considerationScore;
                if (score == 0)
                {
                    action.Score = score;
                    return action.Score;
                }
            }

            var modFactor = 1 - 1 / action.Considerations.Length;
            var makeupValue = (1 - score) * modFactor;
            action.Score = score + score * makeupValue;
            return action.Score;
        }
    }
}