using Components.Client.Character.Movement;
using Components.Server.Character.Movement;
using Leopotam.EcsLite;
using Utils;

namespace Systems.Server.CharacterMovement
{
    public class MoveCommandSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld ();
            var filter = world.Filter<MoveCommand>().End();
            
            foreach (var entity in filter)
            {
                var command = world.GetPool<MoveCommand>().Get(entity);
                
                world.GetPool<MovableComponent>().Del(entity);
                ref var rotateBeforeMovingComponent = ref world.GetPool<RotateBeforeMovingComponent>().AddOrGet(entity);
                
                rotateBeforeMovingComponent.TargetPosition = command.TargetPosition;
                
                world.GetPool<MoveCommand>().Del(entity);
            }
        }
    }
}