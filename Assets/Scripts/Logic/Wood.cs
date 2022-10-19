using Infrastructure;
using Lekret.Ecs;
using UnityEngine;

namespace Logic
{
    public class Wood : MonoBehaviour
    {
        private void Awake()
        {
            Services.Get<EcsManager>()
                .CreateEntity()
                .Set<Wood>()
                .Set(transform);
        }
    }
}