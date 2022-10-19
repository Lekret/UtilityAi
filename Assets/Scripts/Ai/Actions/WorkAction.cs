using System.Collections;
using Components;
using Infrastructure;
using Lekret.Ecs;
using Logic;
using UnityEngine;
using UnityEngine.AI;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Work", fileName = "WorkAction")]
    public class WorkAction : AiAction
    {
        public float WorkTime;
        public int MoneyGain;
        
        private Filter _woods;
        private ICoroutineRunner _coroutineRunner;

        public override void Init()
        {
            _coroutineRunner = Services.Get<ICoroutineRunner>();
            _woods = Services.Get<EcsManager>()
                .Filter()
                .Inc<Wood>()
                .Inc<Transform>()
                .End();
        }

        public override void Execute(Entity entity)
        {
            _coroutineRunner.StartCoroutine(Sleep(entity));
        }
        
        private IEnumerator Sleep(Entity entity)
        {
            var navMeshAgent = entity.Get<NavMeshAgent>();
            var stats = entity.Get<AiStats>();
            var brain = entity.Get<AiBrain>();
            var wood = _woods.GetSingle();
            var woodTransform = wood.Get<Transform>();
            
            navMeshAgent.SetDestination(woodTransform.position);
            yield return null;
            
            while (navMeshAgent.remainingDistance > Vector3.kEpsilon)
            {
                yield return null;
            }

            yield return new WaitForSeconds(WorkTime);
            stats.ChangeMoney(MoneyGain);
            brain.FindNewAction();
        }
    }
}