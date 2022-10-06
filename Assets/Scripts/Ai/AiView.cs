using Configuration;
using Infrastructure;
using SimpleEcs;
using UnityEngine;
using UnityEngine.AI;

namespace Ai
{
    public class AiView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private AiBrainConfig _brainConfig;
        [SerializeField] private AiStats _stats;
        
        private void Awake()
        {
            var actions = _brainConfig.GetActionsCopy();
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