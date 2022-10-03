using Ai;
using UnityEngine;

public abstract class AiAction : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _score;
    [SerializeField] private AiConsideration[] _considerations;

    public AiConsideration[] Considerations => _considerations;
    
    public float Score
    {
        get => _score;
        set => _score = Mathf.Clamp01(value);
    }
    
    public abstract void Execute(AiController ai);
}