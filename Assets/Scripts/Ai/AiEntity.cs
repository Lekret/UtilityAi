using System;
using UnityEngine;
using UnityEngine.AI;

namespace Ai
{
    public class AiEntity : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private AiStats _stats;
        [SerializeField] private AiAction[] _actions;

        private AiBrain _brain;

        public AiStats Stats => _stats;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        
        private void Awake()
        {
            var actions = Array.ConvertAll(_actions, AiAction.Copy);
            InitializeActions(actions);
            _brain = new AiBrain(this, actions);
            _brain.UpdateBestAction();
        }

        private static void InitializeActions(AiAction[] actions)
        {
            foreach (var act in actions)
            {
                foreach (var c in act.Considerations)
                {
                    c.Init();
                }
                act.Init();
            }
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