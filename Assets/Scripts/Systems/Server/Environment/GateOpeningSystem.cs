using Components.Client.Environment;
using Components.Server.Environment;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Server.Environment
{
    public class GateOpeningSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EnvironmentTypeComponent, TriggerComponent> _buttonFilter;
        private readonly EcsFilter<EnvironmentTypeComponent, AnimationTimeComponent, LerpTimeComponent> _gateFilter;
        public void Run()
        {
            foreach (var i in _buttonFilter)
            {
                var environmentComponent = _buttonFilter.Get1(i);
                var buttonComponent = _buttonFilter.Get2(i);
                
                foreach (var j in _gateFilter)
                {
                    var gateComponent = _gateFilter.Get1(j);
                    var animationTimeComponent = _gateFilter.Get2(j);
                    ref var lerpTimeComponent = ref _gateFilter.Get3(j);
                    if (gateComponent.EnvironmentType != environmentComponent.EnvironmentType) continue;
                    if (buttonComponent.TriggerBehaviour.IsTriggered != (lerpTimeComponent.StartTime == 0)) continue;
                    
                    var leftPercent = (1 - lerpTimeComponent.StartPercent);
                    if (buttonComponent.TriggerBehaviour.IsTriggered)
                    {
                        lerpTimeComponent.StartTime = Time.time;
                        var leftTime = animationTimeComponent.Time * leftPercent;
                                
                        lerpTimeComponent.EndTime = Time.time + leftTime;
                    }
                    else
                    {
                        var currentPercent = (Time.time - lerpTimeComponent.StartTime)
                            / (lerpTimeComponent.EndTime - lerpTimeComponent.StartTime) *
                            leftPercent + lerpTimeComponent.StartPercent;
                        lerpTimeComponent.StartPercent = currentPercent;
                        lerpTimeComponent.EndTime = 0;
                        lerpTimeComponent.StartTime = 0;
                    }
                }
            }
        }
    }
}