using Leopotam.Ecs;
using Systems;
using Systems.Client;
using Systems.Server;
using UnityEngine;

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
        _systemsStartups = new ISystemsStartup[] { new ClientSystemsStartup(), new ServerSystemsStartup()};

        InitSystems();
    }

    private void InitSystems()
    {
        _preUpdateSystems = new EcsSystems(_world);
        _updateSystems = new EcsSystems(_world);
        _postUpdateSystems = new EcsSystems(_world);
        
        foreach (var systemsStartup in _systemsStartups)
        {
            _preUpdateSystems.Add(systemsStartup.GetPreUpdateSystems(_world));
            _updateSystems.Add(systemsStartup.GetUpdateSystems(_world));
            _postUpdateSystems.Add(systemsStartup.GetPostUpdateSystems(_world));
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
