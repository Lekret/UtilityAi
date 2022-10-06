using Infrastructure;
using SimpleEcs;
using UnityEngine;

namespace Logic
{
    public class Food : MonoBehaviour
    {
        private void Awake()
        {
            Services.Get<EcsManager>()
                .CreateEntity()
                .Set<Food>()
                .Set(transform);
        }
    }
}