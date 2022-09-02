using Components.Client.CharacterMovement;
using Components.Server.Character;
using Leopotam.Ecs;

namespace Systems.Client.CharacterMovement
{
    public class ClientMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<OrientationComponent, TransformComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var orientation = _filter.Get1(i);
                ref var transform = ref _filter.Get2(i);

                transform.Transform.position = orientation.Position;
                transform.Transform.rotation = orientation.Rotation;
            }
        }
    }
}