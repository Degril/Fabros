using Components.Server.Character;
using Components.Server.Character.Movement;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems.Server.CharacterMovement
{
    public class MoveSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld ();
            var filter = world.Filter<MovableComponent>().Inc<OrientationComponent>().End();
            var time = Time.time;
            
            foreach (var entity in filter)
            {
                ref var movableCommand = ref world.GetPool<MovableComponent>().Get(entity);
                ref var orientation = ref world.GetPool<OrientationComponent>().Get(entity);

                var totalMovingTime = movableCommand.MovingEndTime - movableCommand.MovingStartTime;
                
                var currentMovingTIme = time - movableCommand.MovingStartTime;


                var nextPosition = Vector3.Lerp(
                    movableCommand.FromPosition
                    , movableCommand.TargetPosition,
                    currentMovingTIme / totalMovingTime);

                orientation.Position = nextPosition;
                    
                if(currentMovingTIme >= totalMovingTime)
                    world.GetPool<MovableComponent>().Del(entity);
            }
        }
    }
}