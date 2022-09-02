using Leopotam.Ecs;
using Services;
using Services.Client;
using Systems.Client;
using Systems.Server;
using UnityEngine;
using Voody.UniLeo;

namespace Systems
{
    public class EcsGameStartup : MonoBehaviour
    {
        [SerializeField] private EntityFactory entityFactory;
        
        private EcsWorld _world;
        private EcsSystems _preUpdateSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _postUpdateSystems;

        private ISystemsStartup[] _systemsStartups;
        private EcsSystems[] _systemsQueue;
    
        private void Awake()
        {
            _world = new EcsWorld();
            _systemsStartups = new ISystemsStartup[] { new ClientSystemsStartup(), new ServerSystemsStartup()};

            InitSystems();
            entityFactory.SpawnPlayer(_world);
        }

        private void InitSystems()
        {
            _preUpdateSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);
            _postUpdateSystems = new EcsSystems(_world);
            var services = new ClientServices();
            _systemsQueue = new[] { _preUpdateSystems, _updateSystems, _postUpdateSystems };
        
            foreach (var systemsStartup in _systemsStartups)
            {
                _preUpdateSystems.Add(systemsStartup.GetPreUpdateSystems(_world, services));
                _updateSystems.Add(systemsStartup.GetUpdateSystems(_world, services));
                _postUpdateSystems.Add(systemsStartup.GetPostUpdateSystems(_world, services));
                
                
            }

            foreach (var ecsSystems in _systemsQueue)
            {
                ecsSystems.ConvertScene();
                ecsSystems.Init();
            }
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
