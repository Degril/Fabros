using Components.Both.Character;
using Components.Both.Character.Movement;
using Components.Client.CharacterMovement;
using Components.Server.Character;
using Components.Server.CharacterMovement;
using Data;
using Data.Character;
using Leopotam.Ecs;
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
            transformComponent.CharacterController = characterBehaviour.CharacterController;
        }
    
    }
}
