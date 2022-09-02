using System;
using Services.Client;
using UnityEngine;

namespace Components.Client.Environment
{
    [Serializable]
    public struct TriggerComponent
    {
        [field: SerializeField] public TriggerBehaviour TriggerBehaviour { get; private  set; }
    }

}