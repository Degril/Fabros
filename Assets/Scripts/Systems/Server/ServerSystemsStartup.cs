using System.Collections.Generic;
using Leopotam.EcsLite;
using Services;
using Systems.Server.CharacterMovement;
using Systems.Server.Environment;

namespace Systems.Server
{
    public class ServerSystemsStartup : ISystemsStartup
    {
        public IEnumerable<IEcsSystem> GetPreUpdateSystems(IServices services)
        {
            return new IEcsSystem[]
            {
            };
        }

        public IEnumerable<IEcsSystem> GetUpdateSystems(IServices services)
        {
            return new IEcsSystem[]
            {
                new MoveCommandSystem(),
                new PreMovingRotationSystem(),
                new MoveSystem(),
                new GateOpeningSystem(),
                new CharacterStateSystem(),
            };
        }

        public IEnumerable<IEcsSystem> GetPostUpdateSystems(IServices services)
        {
            return new IEcsSystem[]
            {
            };
        }
    }
}