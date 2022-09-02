using Components.Client;
using Components.Server.Character;
using Components.Server.Environment;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Client.Environment
{
    public class GateAnimationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<LerpTimeComponent, MovingDataAnimationComponent, OrientationComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var lerpTimeComponent = _filter.Get1(i);
                var movingDataAnimationComponent = _filter.Get2(i);
                ref var orientation = ref _filter.Get3(i);
                
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