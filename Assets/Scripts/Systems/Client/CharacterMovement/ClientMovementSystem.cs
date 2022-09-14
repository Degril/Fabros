using Components.Server.Character;
using Leopotam.EcsLite;
using Services.Client.CharacterMovement;

namespace Systems.Client.CharacterMovement
{
    public class ClientMovementSystem : IEcsRunSystem
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
                if (float.IsNaN(orientation.Position.x))
                {
                    orientation.Position = transform.Transform.position;
                    orientation.Rotation = transform.Transform.rotation;
                }
                else
                {
                    transform.Transform.position = orientation.Position;
                    transform.Transform.rotation = orientation.Rotation;
                }
            }
        }
    }
}