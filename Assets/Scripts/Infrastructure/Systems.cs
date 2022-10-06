namespace Infrastructure
{
    public interface ISystem { }

    public interface IInitSystem : ISystem
    {
        void Init();
    }

    public interface ITickSystem : ISystem
    {
        void Tick();
    }
}