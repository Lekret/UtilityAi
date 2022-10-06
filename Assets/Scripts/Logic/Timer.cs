namespace Logic
{
    public class Timer
    {
        private readonly float _time;
        private float _currentTime;
        
        public Timer(float time)
        {
            _time = time;
            _currentTime = time;
        }

        public bool Tick(float dt)
        {
            _currentTime -= dt;
            if (_currentTime <= 0)
            {
                _currentTime = _time;
                return true;
            }
            return false;
        }
    }
}