using Leopotam.Ecs;
using Services.Client;
using Systems.Client;
using Systems.Server;
using UnityEngine;

namespace Systems.Both
{
    public class EcsGameStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _preUpdateSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _postUpdateSystems;

        private ISystemsStartup[] _systemsStartups;
        private EcsSystems[] _systemsQueue;
    
        private void Start()
        {
            _world = new EcsWorld();
            _systemsQueue = new[] { _preUpdateSystems, _updateSystems, _postUpdateSystems };
            _systemsStartups = new ISystemsStartup[] { new ClientSystemsStartup(), new ServerSystemsStartup(), new BothSystemStartup()};

            InitSystems();
        }

        private void InitSystems()
        {
            _preUpdateSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);
            _postUpdateSystems = new EcsSystems(_world);
            var services = new ClientServices();
        
            foreach (var systemsStartup in _systemsStartups)
            {
                _preUpdateSystems.Add(systemsStartup.GetPreUpdateSystems(_world, services));
                _updateSystems.Add(systemsStartup.GetUpdateSystems(_world, services));
                _postUpdateSystems.Add(systemsStartup.GetPostUpdateSystems(_world, services));
            }
        
            foreach (var ecsSystems in _systemsQueue)
                ecsSystems.Init();
        }
    

        private void Update()
        {
            foreach (var ecsSystems in _systemsQueue)
                ecsSystems?.Run();
        }

        private void OnDestroy()
        {
            if (_postUpdateSystems == null)
                return;
        
            foreach (var ecsSystems in _systemsQueue)
                ecsSystems.Destroy();
        
            _preUpdateSystems = null;
            _updateSystems = null;
            _postUpdateSystems = null;
        
            _world.Destroy ();
            _world = null;
        }
    }
}
