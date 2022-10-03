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
                if (ScoreAction(_actions[i]) > bestScore)
                {
                    bestActionIdx = i;
                    bestScore = _actions[i].Score;
                }
            }

            _bestAction = _actions[bestActionIdx];
            _foundBestAction = true;
        }

        private float ScoreAction(AiAction action)
        {
            var score = 1f;
            foreach (var consideration in action.Considerations)
            {
                var considerationScore = consideration.ScoreConsideration(_ai);
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