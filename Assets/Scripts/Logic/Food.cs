using Infrastructure;
using Lekret.Ecs;
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