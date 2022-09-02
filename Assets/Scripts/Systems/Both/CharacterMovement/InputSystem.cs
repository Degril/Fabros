using Components.Both.Character.Movement;
using Leopotam.Ecs;
using Services.Both.CharacterMovement;

namespace Systems.Both.CharacterMovement
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<TargetPositionComponent> _filter;

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
                _filter.Get1(i).TargetPosition = targetPosition;
            }
        }
    }
}