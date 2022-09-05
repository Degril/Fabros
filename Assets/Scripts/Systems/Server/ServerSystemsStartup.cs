using Components.Client.Character.Movement;
using Leopotam.Ecs;
using Services;
using Systems.Server.CharacterMovement;
using Systems.Server.Environment;

namespace Systems.Server
{
    public class ServerSystemsStartup : ISystemsStartup
    {
        public EcsSystems GetPreUpdateSystems(EcsWorld world, IServices services)
        {
            return new EcsSystems(world)
                .Add(new MoveCommandSystem())
                .OneFrame<MoveCommand>();
        }

        public EcsSystems GetUpdateSystems(EcsWorld world, IServices services)
        {
            return new EcsSystems(world)
                .Add(new PremovingRotationSystem())
                .Add(new MoveSystem())
                .Add(new GateOpeningSystem())
                .Add(new CharacterStateSystem());
        }

        public EcsSystems GetPostUpdateSystems(EcsWorld world, IServices services)
        {
            return new EcsSystems(world);
        }
    }
}