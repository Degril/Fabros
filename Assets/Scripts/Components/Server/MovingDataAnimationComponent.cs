using System;
using UnityEngine;

namespace Components.Server
{
    [Serializable]
    public struct MovingDataAnimationComponent
    {
        public Vector3 startPosition;
        public Vector3 endPosition;
    }
}