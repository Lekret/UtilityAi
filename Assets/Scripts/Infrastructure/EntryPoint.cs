using Logic;
using SimpleEcs;
using Systems;
using UnityEngine;

namespace Infrastructure
{
    [DefaultExecutionOrder(-100)]
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        public SceneData SceneData;
        
        private EcsSystems _systems;
        
        private void Awake()
        {
            Services.Set(new EcsManager());
            Services.Set(SceneData);
            Services.Set<ICoroutineRunner>(this);
            _systems = new EcsSystems()
                .Add(new UpdateAiBrain())
                .Add(new DecreaseStats());
        }

        private void Start()
        {
            _systems.Init();
        }

        private void Update()
        {
            _systems.Tick();
        }
    }
}