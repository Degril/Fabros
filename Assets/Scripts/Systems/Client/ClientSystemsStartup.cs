using System.Collections.Generic;
using Leopotam.EcsLite;
using Services;
using Systems.Client.CharacterMovement;
using Systems.Client.Environment;
using Systems.Server.Environment;

namespace Systems.Client
{
    public class ClientSystemsStartup : ISystemsStartup
    {
        public IEnumerable<IEcsSystem> GetPreUpdateSystems(IServices services)
        {
            return new IEcsSystem[]
            {
                new InputSystem(services.Input),
                new GateOpeningSystem()
            };
        }

        public IEnumerable<IEcsSystem> GetUpdateSystems(IServices services)
        {
            return new IEcsSystem[]
            {
            };
        }

        public IEnumerable<IEcsSystem> GetPostUpdateSystems(IServices services)
        {
            return new IEcsSystem[]
            {
                new MovementAnimationSystem(),
                new GateAnimationSystem(),
                new ClientMovementSystem(),
                
            };
        }
    }
}