using System;
using UnityEngine;

namespace Components.Server.Character
{
    [Serializable]
    public struct OrientationComponent
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }
}