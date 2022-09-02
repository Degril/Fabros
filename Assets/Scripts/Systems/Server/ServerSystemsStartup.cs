using Leopotam.Ecs;
using Services.Both;
using Systems.Both;
using Systems.Server.CharacterMovement;

namespace Systems.Server
{
    public class ServerSystemsStartup : ISystemsStartup
    {
        public EcsSystems GetPreUpdateSystems(EcsWorld world, IServices services)
        {
            return new EcsSystems(world);
        }

        public EcsSystems GetUpdateSystems(EcsWorld world, IServices services)
        {
            return new EcsSystems(world)
                .Add(new RotateBeforeMovingSystem())
                .Add(new MoveSystem())
                .Add(new CharacterStateSystem());
        }

        public EcsSystems GetPostUpdateSystems(EcsWorld world, IServices services)
        {
            return new EcsSystems(world);
        }
    }
}