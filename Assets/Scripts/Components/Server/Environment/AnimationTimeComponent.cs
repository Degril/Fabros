using System;
using UnityEngine;

namespace Components.Server.Environment
{
    [Serializable]
    public struct AnimationTimeComponent
    {
        [field: SerializeField] public float Time { get; private set; }
    }
}