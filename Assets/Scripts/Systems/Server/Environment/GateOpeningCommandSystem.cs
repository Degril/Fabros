using Components.Client.Environment;
using Components.Server.Environment;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems.Server.Environment
{
    public class GateOpeningCommandSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld ();
     
            var filter = world.Filter<ButtonChangedStateCommand>()
                .Inc<AnimationTimeComponent>()
                .Inc<LerpTimeComponent>().End();
            
            var currentTime = Time.time;
            
            foreach (var entity in filter)
            {
                var buttonChangedStateCommand = world.GetPool<ButtonChangedStateCommand>().Get(entity);
                var animationTimeComponent = world.GetPool<AnimationTimeComponent>().Get(entity);
                ref var lerpTimeComponent = ref world.GetPool<LerpTimeComponent>().Get(entity);
                
                var leftPercent = (1 - lerpTimeComponent.StartPercent);

                if (buttonChangedStateCommand.IsPressed)
                {
                    lerpTimeComponent.StartTime = currentTime;
                    var leftTime = animationTimeComponent.time * leftPercent;
                                
                    lerpTimeComponent.EndTime = currentTime + leftTime;
                }
                else
                {
                    var currentPercent = (currentTime - lerpTimeComponent.StartTime)
                        / (lerpTimeComponent.EndTime - lerpTimeComponent.StartTime) *
                        leftPercent + lerpTimeComponent.StartPercent;
                    lerpTimeComponent.StartPercent = currentPercent;
                    lerpTimeComponent.EndTime = 0;
                    lerpTimeComponent.StartTime = 0;
                }
                
                world.GetPool<ButtonChangedStateCommand>().Del(entity);
            }
        }
    }
}