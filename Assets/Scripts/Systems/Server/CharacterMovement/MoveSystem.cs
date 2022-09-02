using Components.Server.Character;
using Components.Server.Character.Movement;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Server.CharacterMovement
{
    public class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent, OrientationComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                ref var movableCommand = ref _filter.Get1(i);
                ref var orientation = ref _filter.Get2(i);

                var totalMovingTime = movableCommand.MovingEndTime - movableCommand.MovingStartTime;
                var currentMovingTIme = Time.time - movableCommand.MovingStartTime;


                var nextPosition = Vector3.Lerp(
                    movableCommand.FromPosition
                    , movableCommand.TargetPosition,
                    currentMovingTIme / totalMovingTime);

                orientation.Position = nextPosition;
                    
                if(currentMovingTIme >= totalMovingTime)
                    entity.Del<MovableComponent>();
            }
        }
    }
}