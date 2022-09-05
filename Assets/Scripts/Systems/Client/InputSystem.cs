﻿using Components.Client.Character.Movement;
using Components.Server.Character;
using Components.Server.Character.Movement;
using Leopotam.Ecs;
using Services.Client.CharacterMovement;

namespace Systems.Client
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
                ref var moveCommand = ref entity.Get<MoveCommand>();
                moveCommand.TargetPosition = targetPosition;
            }
        }
    }
}