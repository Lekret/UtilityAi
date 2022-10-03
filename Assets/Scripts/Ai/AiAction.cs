using Ai;
using UnityEngine;

public abstract class AiAction : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private AiConsideration[] _considerations;

    public AiConsideration[] Considerations => _considerations;

    public abstract void Execute(AiEntity entity);
}