
using Components.Client.Environment;
using Components.Server.Environment;
using Leopotam.EcsLite;
using UnityEngine;
using Utils;

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
                ref var buttonTriggerComponent = ref world.GetPool<TriggerComponent>().Get(buttonEntity);
                
                foreach (var gateEntity in gateFilter)
                {
                    var gateEnvironmentComponent = world.GetPool<EnvironmentTypeComponent>().Get(gateEntity);
                    
                    if (gateEnvironmentComponent.environmentType != buttonEnvironmentComponent.environmentType) continue;
                    if (buttonTriggerComponent.triggerBehaviour.IsTriggered == buttonTriggerComponent.LastCheckedTrigger) continue;
                    
                    ref var buttonCommand = ref world.GetPool<ButtonChangedStateCommand>().AddOrGet(gateEntity);
                    buttonCommand.IsPressed = buttonTriggerComponent.triggerBehaviour.IsTriggered;
                    buttonTriggerComponent.LastCheckedTrigger = buttonTriggerComponent.triggerBehaviour.IsTriggered;
                }
            }
        }
    }
}