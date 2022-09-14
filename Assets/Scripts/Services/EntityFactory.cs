using Components.Client.Character;
using Components.Client.Character.Movement;
using Components.Server.Character;
using Components.Server.Character.Movement;
using Data;
using Leopotam.EcsLite;
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
            ref var movableData = ref world.GetPool<MovableDataComponent>().Add(characterEntity);
            movableData.MovementSpeed = movementSpeed;
            movableData.RotationSpeed = rotationSpeed;
            ref var orientation = ref world.GetPool<OrientationComponent>().Add(characterEntity);
            orientation.Position = mainCharacterSpawnPosition.position;
            ref var transformComponent = ref world.GetPool<TransformComponent>().Add(characterEntity);
            world.GetPool<MovableStateComponent>().Add(characterEntity);
            world.GetPool<PlayerTag>().Add(characterEntity);
            ref var animationComponent = ref world.GetPool<AnimationComponent>().Add(characterEntity);

            var characterBehaviour = Instantiate(DataProvider.Instance.CharacterBehaviour);
            
            animationComponent.Animator = characterBehaviour.Animator;
            transformComponent.Transform = characterBehaviour.transform;
        }
    
    }
}
