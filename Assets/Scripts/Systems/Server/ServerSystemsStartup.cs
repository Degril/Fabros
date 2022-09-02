using Leopotam.Ecs;

namespace Systems.Server
{
    public class ServerSystemsStartup : ISystemsStartup
    {
        public EcsSystems GetPreUpdateSystems(EcsWorld world)
        {
            var ecsSystems = new EcsSystems(world);
            return ecsSystems;
        }

        public EcsSystems GetUpdateSystems(EcsWorld world)
        {
            var ecsSystems = new EcsSystems(world);
            return ecsSystems;
        }

        public EcsSystems GetPostUpdateSystems(EcsWorld world)
        {
            var ecsSystems = new EcsSystems(world);
            return ecsSystems;
        }
    }
}