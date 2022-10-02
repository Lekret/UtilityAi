using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;

    public void SetDestination(Vector3 destination)
    {
        _navMeshAgent.SetDestination(destination);
    }
}