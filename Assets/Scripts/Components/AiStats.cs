using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class AiStats
    {
        public int Satiety;
        public int MaxSatiety;
        public int Energy;
        public int MaxEnergy;
        public int Money;

        public void ChangeEnergy(int delta)
        {
            Energy = Mathf.Clamp(Energy + delta, 0, MaxEnergy);
        }

        public void ChangeMoney(int delta)
        {
            Money = Mathf.Max(Money + delta, 0);
        }

        public void ChangeSatiety(int delta)
        {
            Satiety = Mathf.Clamp(Satiety + delta, 0, MaxSatiety);
        }
    }
}