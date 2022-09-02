using Components.Both.Character.Movement;
using Components.Server.Character;
using Components.Server.CharacterMovement;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Server.CharacterMovement
{
    public class RotateBeforeMovingSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableDataComponent, RotateBeforeMovingComponent, OrientationComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                var movableData = _filter.Get1(i);
                ref var rotateComponent = ref _filter.Get2(i);
                ref var orientation = ref _filter.Get3(i);

                var direction = (rotateComponent.TargetPosition - orientation.Position).normalized;
                direction.y = 0;

                var transformForward = orientation.Rotation * Vector3.forward;

                var rotationDistance = Vector3.Dot(transformForward, direction);
                if (rotationDistance < 0.95f)
                {
                    var singleStep = movableData.RotationSpeed * Time.deltaTime;
                    
                    var newDirection = Vector3.RotateTowards(transformForward, direction, singleStep, 0.0f);
                    orientation.Rotation = Quaternion.LookRotation(newDirection);
                }
                else
                {
                    ref var movableComponent = ref entity.Get<MovableComponent>();

                    movableComponent.FromPosition = orientation.Position;
                    movableComponent.TargetPosition = rotateComponent.TargetPosition;
                    
                    var distance = (rotateComponent.TargetPosition - orientation.Position).magnitude;
                    
                    movableComponent.MovingStartTime = Time.time;
                    movableComponent.MovingEndTime = Time.time + distance / movableData.MovementSpeed;
                    entity.Del<RotateBeforeMovingComponent>();
                }
            }
        }
    }
}