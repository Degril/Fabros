using Components.Server.Character;
using Components.Server.Character.Movement;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems.Server.CharacterMovement
{
    public class PreMovingRotationSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld ();
            var filter = world.Filter<MovableDataComponent>()
                .Inc<RotateBeforeMovingComponent>()
                .Inc<OrientationComponent>().End();
            
            foreach (var entity in filter)
            {
                var movableData = world.GetPool<MovableDataComponent>().Get(entity);
                ref var rotateComponent = ref world.GetPool<RotateBeforeMovingComponent>().Get(entity);
                ref var orientation = ref world.GetPool<OrientationComponent>().Get(entity);

                var direction = (rotateComponent.TargetPosition - orientation.Position).normalized;
                direction.y = 0;

                var transformForward = orientation.Rotation * Vector3.forward;

                var rotationDistance = Vector3.Dot(transformForward, direction);
                if (rotationDistance < 0.97f)
                {
                    var singleStep = movableData.RotationSpeed * Time.deltaTime;
                    
                    var newDirection = Vector3.RotateTowards(transformForward, direction, singleStep, 0.0f);
                    orientation.Rotation = Quaternion.LookRotation(newDirection);
                }
                else
                {
                    ref var movableComponent = ref world.GetPool<MovableComponent>().Add(entity);
                    movableComponent.FromPosition = orientation.Position;
                    movableComponent.TargetPosition = rotateComponent.TargetPosition;
                    
                    var distance = (rotateComponent.TargetPosition - orientation.Position).magnitude;
                    
                    movableComponent.MovingStartTime = Time.time;
                    movableComponent.MovingEndTime = Time.time + distance / movableData.MovementSpeed;
                    world.GetPool<RotateBeforeMovingComponent>().Del(entity);
                }
            }
        }
    }
}