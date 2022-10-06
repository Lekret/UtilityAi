using Ai;
using Infrastructure;
using SimpleEcs;

namespace Systems
{
    public class UpdateAiBrain : IInitSystem, ITickSystem
    {
        private readonly EcsFilter _filter;

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
        
        public void Tick()
        {
            foreach (var entity in _filter)
            {
                entity.Get<AiBrain>().TryExecuteBestAction();
            }
        }
    }
}