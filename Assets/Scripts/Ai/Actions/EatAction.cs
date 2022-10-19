using System.Collections;
using Components;
using Infrastructure;
using Lekret.Ecs;
using Logic;
using UnityEngine;
using UnityEngine.AI;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Eat", fileName = "EatAction")]
    public class EatAction : AiAction
    {
        public float EatTime;
        public int SatietyGain;

        private Filter _foods;
        private ICoroutineRunner _coroutineRunner;

        public override void Init()
        {
            _coroutineRunner = Services.Get<ICoroutineRunner>();
            _foods = Services.Get<EcsManager>()
                .Inc<Food>()
                .Inc<Transform>()
                .End();
        }

        public override void Execute(Entity entity)
        {
            _coroutineRunner.StartCoroutine(Eat(entity));
        }
        
        private IEnumerator Eat(Entity entity)
        {
            var navMeshAgent = entity.Get<NavMeshAgent>();
            var stats = entity.Get<AiStats>();
            var brain = entity.Get<AiBrain>();
            var food = _foods.GetSingle();
            var foodTransform = food.Get<Transform>();
            
            navMeshAgent.SetDestination(foodTransform.position);
            yield return null;
            
            while (navMeshAgent.remainingDistance > Vector3.kEpsilon)
            {
                yield return null;
            }

            yield return new WaitForSeconds(EatTime);
            stats.ChangeSatiety(SatietyGain);
            brain.FindNewAction();
        }
    }
}