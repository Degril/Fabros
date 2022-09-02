using Leopotam.Ecs;
using Services.Both;
using Systems.Both;

namespace Systems.Server
{
    public class ServerSystemsStartup : ISystemsStartup
    {
        public EcsSystems GetPreUpdateSystems(EcsWorld world, IServices services)
        {
            var ecsSystems = new EcsSystems(world);
            return ecsSystems;
        }

        public EcsSystems GetUpdateSystems(EcsWorld world, IServices services)
        {
            var ecsSystems = new EcsSystems(world);
            return ecsSystems;
        }

        public EcsSystems GetPostUpdateSystems(EcsWorld world, IServices services)
        {
            var ecsSystems = new EcsSystems(world);
            return ecsSystems;
        }
    }
}