using Leopotam.Ecs;
using Services;
using Systems.Client.CharacterMovement;
using Systems.Client.Environment;
using Systems.Server.CharacterMovement;

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
                .Add(new MovementAnimationSystem())
                .Add(new GateAnimationSystem())
                .Add(new ClientMovementSystem());
        }
    }
}