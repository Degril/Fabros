using System;
using UnityEngine;

namespace Components.Client
{
    [Serializable]
    public struct MovingDataAnimationComponent
    {
        [field: SerializeField] public Vector3 StartPosition { get; private set; }
        [field: SerializeField] public Vector3 EndPosition { get; private set; }
    }
}