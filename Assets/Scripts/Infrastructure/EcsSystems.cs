using System.Collections.Generic;

namespace Infrastructure
{
    public class EcsSystems : IInitSystem, ITickSystem
    {
        private readonly List<IInitSystem> _initSystems = new List<IInitSystem>();
        private readonly List<ITickSystem> _tickSystems = new List<ITickSystem>();

        public EcsSystems Add(ISystem system)
        {
            if (system is IInitSystem initSystem)
                _initSystems.Add(initSystem);
            if (system is ITickSystem tickSystem)
                _tickSystems.Add(tickSystem);
            return this;
        }

        public void Init()
        {
            foreach (var system in _initSystems)
            {
                system.Init();
            }
        }

        public void Tick()
        {
            foreach (var system in _tickSystems)
            {
                system.Tick();
            }
        }
    }
}