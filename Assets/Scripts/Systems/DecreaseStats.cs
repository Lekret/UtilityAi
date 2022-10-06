using Components;
using Infrastructure;
using Logic;
using SimpleEcs;
using UnityEngine;

namespace Systems
{
    public class DecreaseStats : ITickSystem
    {
        private readonly Timer _timer = new Timer(1);
        private readonly EcsFilter _stats;

        public DecreaseStats()
        {
            _stats = Services.Get<EcsManager>()
                .Filter()
                .Inc<AiStats>()
                .End();
        }

        public void Tick()
        {
            if (!_timer.Tick(Time.deltaTime))
                return;
            
            foreach (var entity in _stats)
            {
                var stats = entity.Get<AiStats>();
                stats.ChangeEnergy(-1);
                stats.ChangeMoney(-1);
                stats.ChangeSatiety(-1);
            }
        }
    }
}