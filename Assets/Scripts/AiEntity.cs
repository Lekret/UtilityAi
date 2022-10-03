using Ai;
using UnityEngine;

public class AiEntity : MonoBehaviour
{
    [SerializeField] private AiMovement _movement;
    [SerializeField] private AiAction[] _actions;

    private AiBrain _brain;
    
    private void Awake()
    {
        _brain = new AiBrain(this, _actions);
        _brain.UpdateBestAction();
    }

    private void Update()
    {
        _brain.TryExecuteBestAction();
    }
    
    public void SetDestination(Vector3 position)
    {
        _movement.SetDestination(position);
    }
    
    public void OnFinishedAction()
    {
        _brain.UpdateBestAction();
    }
}