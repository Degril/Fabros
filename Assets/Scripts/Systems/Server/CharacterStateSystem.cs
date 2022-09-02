using Components.Client.Character.Movement;
using Components.Server.Character.Movement;
using Leopotam.Ecs;

namespace Systems.Server
{
    public class CharacterStateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableDataComponent, MovableStateComponent, MovableComponent> _movingFilter;
        private readonly EcsFilter<MovableDataComponent, MovableStateComponent>.Exclude<MovableComponent> _unMovingFilter;
        public void Run()
        {
            foreach (var i in _movingFilter)
            {
                var movableDataComponent = _movingFilter.Get1(i);
                ref var movableStateComponent = ref _movingFilter.Get2(i);

                movableStateComponent.IsMoving = true;
                movableStateComponent.CurrentSpeed = movableDataComponent.MovementSpeed;
            }
            foreach (var i in _unMovingFilter)
            {
                ref var movableStateComponent = ref _movingFilter.Get2(i);

                movableStateComponent.CurrentSpeed = 0;
                movableStateComponent.IsMoving = false;
            }
        }
        
    }
}