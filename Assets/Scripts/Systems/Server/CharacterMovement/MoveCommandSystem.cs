using Components.Client.Character.Movement;
using Components.Server.Character.Movement;
using Leopotam.Ecs;

namespace Systems.Server.CharacterMovement
{
    public class MoveCommandSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MoveCommand> _filter;

        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var command = _filter.Get1(i);
                var entity = _filter.GetEntity(i);
                entity.Del<MovableComponent>();
                ref var rotateBeforeMovingComponent = ref entity.Get<RotateBeforeMovingComponent>();
                
                rotateBeforeMovingComponent.TargetPosition = command.TargetPosition;
            }
        }
    }
}