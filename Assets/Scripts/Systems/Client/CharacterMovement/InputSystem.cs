using Components.Both.Character;
using Components.Both.Character.Movement;
using Components.Client.CharacterMovement;
using Components.Server.CharacterMovement;
using Leopotam.Ecs;
using Services.Both.CharacterMovement;
using UnityEngine;

namespace Systems.Both.CharacterMovement
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, TransformComponent, MovableDataComponent> _filter;

        private readonly IInput _input;
        
        public InputSystem(IInput input)
        {
            _input = input;
        }
        
        public void Run()
        {
            if (!_input.IsFireButtonPressed(out var targetPosition)) return;
            
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                entity.Del<MovableComponent>();
                ref var rotateBeforeMovingComponent = ref entity.Get<RotateBeforeMovingComponent>();
                
                rotateBeforeMovingComponent.TargetPosition = targetPosition;
            }
        }
    }
}