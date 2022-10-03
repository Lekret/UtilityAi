using UnityEngine;

namespace Ai
{
    public class AiBrain
    {
        private readonly AiController _ai;
        private readonly AiAction[] _actions;
        private AiAction _bestAction;
        private bool _foundBestAction;

        public AiBrain(AiController ai, AiAction[] actions)
        {
            _ai = ai;
            _actions = actions;
        }
        
        public void TryExecuteBestAction()
        {
            if (_foundBestAction)
            {
                _foundBestAction = false;
                _bestAction.Execute(_ai);
            }
        }
        
        public void UpdateBestAction()
        {
            if (_actions.Length == 0)
            {
                Debug.LogError("Actions count should be above 0");
                return;
            }
            
            var bestScore = 0f;
            var bestActionIdx = 0;
            for (var i = 0; i < _actions.Length; i++)
            {
                var newScore = EvaluateScore(_actions[i]);
                if (newScore > bestScore)
                {
                    bestActionIdx = i;
                    bestScore = newScore;
                }
            }
            
            _bestAction = _actions[bestActionIdx];
            _foundBestAction = true;
        }

        private float EvaluateScore(AiAction action)
        {
            if (action.Considerations.Length == 0)
            {
                Debug.LogError("Considerations count should be above 0");
                return 0f;
            }
            
            var score = 1f;
            foreach (var consideration in action.Considerations)
            {
                var considerationScore = Mathf.Clamp01(consideration.EvaluateScore(_ai));
                score *= considerationScore;
                if (score == 0f)
                    return score;
            }
            
            var modFactor = 1f - 1f / action.Considerations.Length;
            var makeupValue = (1f - score) * modFactor;
            score += score * makeupValue;
            return score;
        }
    }
}