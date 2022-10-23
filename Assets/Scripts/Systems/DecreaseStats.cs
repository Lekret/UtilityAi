using Components;
using Infrastructure;
using Lekret.Ecs;
using Logic;
using UnityEngine;

namespace Systems
{
    public class DecreaseStats : IUpdateSystem
    {
        private readonly IntervalTimer _intervalTimer = new IntervalTimer(1);
        private readonly Filter _stats;

        public DecreaseStats()
        {
            _stats = Services.Get<EcsManager>().Filter(Mask.With<AiStats>());
        }

        public void Update()
        {
            if (!_intervalTimer.Tick(Time.deltaTime))
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