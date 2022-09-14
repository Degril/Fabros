using Components.Client.Character.Movement;
using Components.Server.Character.Movement;
using Leopotam.EcsLite;

namespace Systems.Server
{
    public class CharacterStateSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld ();
            var movingFilter = world.Filter<MovableDataComponent>()
                .Inc<MovableStateComponent>()
                .Inc<MovableComponent>().End();
            
            var unMovingFilter = world.Filter<MovableDataComponent>()
                .Inc<MovableStateComponent>()
                .Exc<MovableComponent>().End();
            
            foreach (var entity in movingFilter)
            {
                var movableDataComponent = world.GetPool<MovableDataComponent>().Get(entity);
                ref var movableStateComponent = ref world.GetPool<MovableStateComponent>().Get(entity);

                movableStateComponent.IsMoving = true;
                movableStateComponent.CurrentSpeed = movableDataComponent.MovementSpeed;
            }
            foreach (var entity in unMovingFilter)
            {
                ref var movableStateComponent = ref world.GetPool<MovableStateComponent>().Get(entity);

                movableStateComponent.CurrentSpeed = 0;
                movableStateComponent.IsMoving = false;
            }
        }
        
    }
}