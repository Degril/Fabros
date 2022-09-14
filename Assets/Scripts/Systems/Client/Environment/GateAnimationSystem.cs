using Components.Client;
using Components.Server.Character;
using Components.Server.Environment;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems.Client.Environment
{
    public class GateAnimationSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld ();
            var filter = world.Filter<LerpTimeComponent>()
                .Inc<MovingDataAnimationComponent>()
                .Inc<OrientationComponent>().End ();
            foreach (var entity in filter)
            {
                var lerpTimeComponent =  world.GetPool<LerpTimeComponent>().Get(entity);
                var movingDataAnimationComponent =  world.GetPool<MovingDataAnimationComponent>().Get(entity);
                ref var orientation = ref  world.GetPool<OrientationComponent>().Get(entity);
                
                if(lerpTimeComponent.StartTime == 0)
                    continue;

                var leftPercent = (1 - lerpTimeComponent.StartPercent);
                
                var currentPercent = (Time.time - lerpTimeComponent.StartTime)
                    / (lerpTimeComponent.EndTime - lerpTimeComponent.StartTime) *
                    leftPercent + lerpTimeComponent.StartPercent;

                orientation.Position = Vector3.Lerp(movingDataAnimationComponent.StartPosition,
                    movingDataAnimationComponent.EndPosition, currentPercent);
            }
        }
    }
}