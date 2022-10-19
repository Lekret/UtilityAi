using Ai;
using Infrastructure;
using Lekret.Ecs;

namespace Systems
{
    public class UpdateAiBrain : IInitSystem, IUpdateSystem
    {
        private readonly Filter _filter;

        public UpdateAiBrain()
        {
            _filter = Services.Get<EcsManager>()
                .Filter()
                .Inc<AiBrain>()
                .End();
        }
        
        public void Init()
        {
            foreach (var entity in _filter)
            {
                entity.Get<AiBrain>().FindNewAction();
            }
        }
        
        public void Update()
        {
            foreach (var entity in _filter)
            {
                entity.Get<AiBrain>().TryExecuteBestAction();
            }
        }
    }
}