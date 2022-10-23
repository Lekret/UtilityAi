using Lekret.Ecs;
using Logic;
using SimpleEcs.Runtime;
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
            var manager = new EcsManager();
            Services.Set(manager);
            Services.Set(SceneData);
            Services.Set<ICoroutineRunner>(this);
            _systems = new EcsSystemsExtended(manager)
                .Add(new UpdateAiBrain())
                .Add(new DecreaseStats());
        }

        private void Start()
        {
            _systems.Init();
        }

        private void Update()
        {
            _systems.Update();
        }

        private void FixedUpdate()
        {
            _systems.FixedUpdate();
        }

        private void LateUpdate()
        {
            _systems.LateUpdate();
        }

        private void OnDestroy()
        {
            _systems.Destroy();
        }
    }
}