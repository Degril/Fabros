using Leopotam.Ecs;
using Services;

namespace Systems
{
    public interface ISystemsStartup
    {
        EcsSystems GetPreUpdateSystems(EcsWorld world, IServices services);
        EcsSystems GetUpdateSystems(EcsWorld world, IServices services);
        EcsSystems GetPostUpdateSystems(EcsWorld world, IServices services);
    }
}