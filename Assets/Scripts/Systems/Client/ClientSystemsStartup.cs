using Leopotam.Ecs;
using Services.Both;
using Systems.Both;
using Systems.Both.CharacterMovement;
using Systems.Client.CharacterMovement;

namespace Systems.Client
{
    public class ClientSystemsStartup : ISystemsStartup
    {
        public EcsSystems GetPreUpdateSystems(EcsWorld world, IServices services)
        {
            return new EcsSystems(world)
                .Add(new InputSystem(services.Input));
        }

        public EcsSystems GetUpdateSystems(EcsWorld world, IServices services)
        {
            return new EcsSystems(world);
        }

        public EcsSystems GetPostUpdateSystems(EcsWorld world, IServices services)
        {
            return new EcsSystems(world)
                .Add(new ClientMoveSystem())
                .Add(new AnimationSystem());
        }
    }
}