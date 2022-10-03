using UnityEngine;

public abstract class AiAction : ScriptableObject
{
    [SerializeField] private Consideration[] _considerations;
    [SerializeField] private string _name;
    [SerializeField] private float _score;

    public Consideration[] Considerations => _considerations;
    
    public float Score
    {
        get => _score;
        set => _score = Mathf.Clamp01(value);
    }
    
    public abstract void Execute();
}