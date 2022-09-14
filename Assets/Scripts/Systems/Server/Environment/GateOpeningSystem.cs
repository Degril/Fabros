using Components.Client.Environment;
using Components.Server.Environment;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems.Server.Environment
{
    public class GateOpeningSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld ();
            var buttonFilter = world.Filter<EnvironmentTypeComponent>()
                .Inc<TriggerComponent>().End();
            
            var gateFilter = world.Filter<EnvironmentTypeComponent>()
                .Inc<AnimationTimeComponent>()
                .Inc<LerpTimeComponent>().End();

            foreach (var buttonEntity in buttonFilter)
            {
                var buttonEnvironmentComponent = world.GetPool<EnvironmentTypeComponent>().Get(buttonEntity);
                var buttonTriggerComponent = world.GetPool<TriggerComponent>().Get(buttonEntity);
                
                foreach (var gateEntity in gateFilter)
                {
                    var gateEnvironmentComponent = world.GetPool<EnvironmentTypeComponent>().Get(gateEntity);
                    var gateAnimationTimeComponent = world.GetPool<AnimationTimeComponent>().Get(gateEntity);
                    ref var gateLerpTimeComponent = ref world.GetPool<LerpTimeComponent>().Get(gateEntity);
                    
                    if (gateEnvironmentComponent.EnvironmentType != buttonEnvironmentComponent.EnvironmentType) continue;
                    if (buttonTriggerComponent.TriggerBehaviour.IsTriggered != (gateLerpTimeComponent.StartTime == 0)) continue;
                    
                    var leftPercent = (1 - gateLerpTimeComponent.StartPercent);
                    if (buttonTriggerComponent.TriggerBehaviour.IsTriggered)
                    {
                        gateLerpTimeComponent.StartTime = Time.time;
                        var leftTime = gateAnimationTimeComponent.Time * leftPercent;
                                
                        gateLerpTimeComponent.EndTime = Time.time + leftTime;
                    }
                    else
                    {
                        var currentPercent = (Time.time - gateLerpTimeComponent.StartTime)
                            / (gateLerpTimeComponent.EndTime - gateLerpTimeComponent.StartTime) *
                            leftPercent + gateLerpTimeComponent.StartPercent;
                        gateLerpTimeComponent.StartPercent = currentPercent;
                        gateLerpTimeComponent.EndTime = 0;
                        gateLerpTimeComponent.StartTime = 0;
                    }
                }
            }
        }
    }
}