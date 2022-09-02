using Components.Client.Character;
using Components.Client.Character.Movement;
using Components.Server.Character;
using Components.Server.Character.Movement;
using Data;
using Leopotam.Ecs;
using Services.Client.CharacterMovement;
using UnityEngine;

namespace Services
{
    public class EntityFactory : MonoBehaviour
    {
        [SerializeField] private Transform mainCharacterSpawnPosition;
    
        public void SpawnPlayer(EcsWorld world)
        {
            const float movementSpeed = 3;
            const float rotationSpeed = 4;
            var characterEntity = world.NewEntity();
            ref var movableData = ref characterEntity.Get<MovableDataComponent>();
            movableData.MovementSpeed = movementSpeed;
            movableData.RotationSpeed = rotationSpeed;
            ref var orientation = ref characterEntity.Get<OrientationComponent>();
            orientation.Position = mainCharacterSpawnPosition.position;
            ref var transformComponent = ref characterEntity.Get<TransformComponent>();
            characterEntity.Get<PlayerTag>();
            characterEntity.Get<MovableStateComponent>();
            ref var animationComponent = ref characterEntity.Get<AnimationComponent>();

            
            var characterBehaviour = Instantiate(DataProvider.Instance.CharacterBehaviour);
            
            animationComponent.Animator = characterBehaviour.Animator;
            transformComponent.Transform = characterBehaviour.transform;
        }
    
    }
}
