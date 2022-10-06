﻿using System.Collections;
using Infrastructure;
using Logic;
using SimpleEcs;
using UnityEngine;
using UnityEngine.AI;

namespace Ai.Actions
{
    [CreateAssetMenu(menuName = "StaticData/Actions/Sleep", fileName = "SleepAction")]
    public class SleepAction : AiAction
    {
        public float SleepTime;
        public int EnergyGain;
        
        private EcsFilter _beds;
        private ICoroutineRunner _coroutineRunner;

        public override void Init()
        {
            _coroutineRunner = Services.Get<ICoroutineRunner>();
            _beds = Services.Get<EcsManager>()
                .Filter()
                .Inc<Bed>()
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
            var bed = _beds.GetSingle();
            var bedTransform = bed.Get<Transform>();
            
            navMeshAgent.SetDestination(bedTransform.position);
            yield return null;
            
            while (navMeshAgent.remainingDistance > Vector3.kEpsilon)
            {
                yield return null;
            }

            yield return new WaitForSeconds(SleepTime);
            stats.ChangeEnergy(EnergyGain);
            brain.FindNewAction();
        }
    }
}