using Leopotam.Ecs;
using Services.Both;
using Systems.Both.CharacterMovement;

namespace Systems.Both
{
    public class BothSystemStartup: ISystemsStartup
    {
        public EcsSystems GetPreUpdateSystems(EcsWorld world, IServices services)
        {
            var ecsSystems = new EcsSystems(world);
            
            ecsSystems.Add(new InputSystem(services.Input));
            
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