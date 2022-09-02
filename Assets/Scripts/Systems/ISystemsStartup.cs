using Leopotam.Ecs;

namespace Systems
{
    public interface ISystemsStartup
    {
        EcsSystems GetPreUpdateSystems(EcsWorld world);
        EcsSystems GetUpdateSystems(EcsWorld world);
        EcsSystems GetPostUpdateSystems(EcsWorld world);
    }
}