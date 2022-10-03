using UnityEngine;

public class AiBrain : MonoBehaviour
{
    public AiAction BestAction { get; private set; }

    public void UpdateBestAction(AiAction[] actions)
    {
        var bestScore = 0f;
        var bestActionIdx = 0;
        for (var i = 0; i < actions.Length; i++)
        {
            if (ScoreAction(actions[i]) > bestScore)
            {
                bestActionIdx = i;
                bestScore = actions[i].Score;
            }
        }

        BestAction = actions[bestActionIdx];
    }

    private static float ScoreAction(AiAction action)
    {
        var score = 1f;
        foreach (var consideration in action.Considerations)
        {
            var considerationScore = consideration.ScoreConsideration();
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