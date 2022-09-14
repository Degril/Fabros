using Components.Server.Character;
using Leopotam.EcsLite;
using Services.Client.CharacterMovement;

namespace Systems.Client.CharacterMovement
{
    public class ClientMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld ();
            var filter = world.Filter<OrientationComponent>()
                .Inc<TransformComponent>().End ();
            foreach (var entity in filter)
            {
                ref var orientation = ref world.GetPool<OrientationComponent>().Get(entity);
                ref var transform = ref  world.GetPool<TransformComponent>().Get(entity);
                transform.Transform.position = orientation.Position;
                transform.Transform.rotation = orientation.Rotation;
            }
        }

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld ();
            var filter = world.Filter<OrientationComponent>()
                .Inc<TransformComponent>().End ();
            foreach (var entity in filter)
            {
                ref var orientation = ref world.GetPool<OrientationComponent>().Get(entity);
                ref var transform = ref  world.GetPool<TransformComponent>().Get(entity);
                orientation.Position = transform.Transform.position;
                orientation.Rotation = transform.Transform.rotation;
            }
        }
    }
}