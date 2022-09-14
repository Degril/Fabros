using System.Collections.Generic;
using Leopotam.EcsLite;
using Services;

namespace Systems
{
    public interface ISystemsStartup
    {
        IEnumerable<IEcsSystem> GetPreUpdateSystems(IServices services);
        IEnumerable<IEcsSystem> GetUpdateSystems(IServices services);
        IEnumerable<IEcsSystem> GetPostUpdateSystems(IServices services);
    }
}