using Components.Server.Character;
using Leopotam.Ecs;
using Services.Client.CharacterMovement;

namespace Systems.Client.CharacterMovement
{
    public class ClientMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<OrientationComponent, TransformComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var orientation = _filter.Get1(i);
                ref var transform = ref _filter.Get2(i);
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