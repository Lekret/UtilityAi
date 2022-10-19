using Infrastructure;
using Lekret.Ecs;
using UnityEngine;

namespace Logic
{
    public class Bed : MonoBehaviour
    {
        private void Awake()
        {
            Services.Get<EcsManager>()
                .CreateEntity()
                .Set<Bed>()
                .Set(transform);
        }
    }
}