using Components.Client.Character.Movement;
using Components.Server.Character;
using Components.Server.Character.Movement;
using Leopotam.EcsLite;
using Services.Client.CharacterMovement;
using Utils;

namespace Systems.Client
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly IInput _input;
        
        public InputSystem(IInput input)
        {
            _input = input;
        }
        
        public void Run(IEcsSystems systems)
        {
            if (!_input.IsFireButtonPressed(out var targetPosition)) return;
            
            var world = systems.GetWorld ();
            var filter = world.Filter<PlayerTag>()
                .Inc<TransformComponent>()
                .Inc<MovableDataComponent>().End ();
            
            foreach (var entity in filter)
            {
                ref var moveCommand = ref world.GetPool<MoveCommand>().AddOrGet(entity);
                moveCommand.TargetPosition = targetPosition;
            }
        }
    }
}