using System;
using Services.Server;
using UnityEngine;

namespace Components.Client.Environment
{
    [Serializable]
    public struct EnvironmentTypeComponent
    {
        [field: SerializeField] public EnvironmentType EnvironmentType { get; private set; }
    }
    
}