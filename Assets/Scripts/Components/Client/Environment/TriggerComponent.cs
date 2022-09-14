using System;
using Services.Client;

namespace Components.Client.Environment
{
    [Serializable]
    public struct TriggerComponent
    {
        public bool LastCheckedTrigger { get; set; }
        
        public TriggerBehaviour triggerBehaviour;
    }

}