using System;
using Infrastructure;
using SimpleEcs;
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
        
        private void Awake()
        {
            var actions = Array.ConvertAll(_actions, AiAction.Copy);
            var entity = Services.Get<EcsManager>().CreateEntity();
            entity
                .Set(_stats)
                .Set(_navMeshAgent)
                .Set(new AiBrain(entity, actions));
            InitializeActions(actions);
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
    }
}