using System;
using UnityEngine;
using UnityEngine.AI;

namespace Ai
{
    public class AiEntity : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private AiAction[] _actions;

        private AiBrain _brain;
        
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        
        private void Awake()
        {
            var actions = Array.ConvertAll(_actions, AiAction.Copy);
            _brain = new AiBrain(this, actions);
            _brain.UpdateBestAction();
        }

        private void Update()
        {
            _brain.TryExecuteBestAction();
        }

        public void OnFinishedAction()
        {
            _brain.UpdateBestAction();
        }
    }
}