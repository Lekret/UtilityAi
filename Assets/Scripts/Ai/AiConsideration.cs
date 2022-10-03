using UnityEngine;

namespace Ai
{
    public abstract class AiConsideration : ScriptableObject
    {
        [SerializeField] private string _name;

        private float _score;

        public float Score
        {
            get => _score;
            set => _score = Mathf.Clamp01(_score);
        }

        public abstract float ScoreConsideration(AiController ai);
    }
}