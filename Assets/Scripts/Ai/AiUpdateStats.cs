using System.Collections;
using UnityEngine;

namespace Ai
{
    public class AiUpdateStats : MonoBehaviour
    {
        [SerializeField] private AiEntity _entity;

        private void Start()
        {
            StartCoroutine(UpdateEachSecond());
        }

        private IEnumerator UpdateEachSecond()
        {
            var waitSecond = new WaitForSeconds(1);
            while (true)
            {
                _entity.Stats.ChangeEnergy(-1);
                _entity.Stats.ChangeMoney(-1);
                _entity.Stats.ChangeSatiety(-1);
                yield return waitSecond;
            }
        }
    }
}