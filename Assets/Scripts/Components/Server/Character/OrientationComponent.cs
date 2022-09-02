using UnityEngine;

namespace Components.Server.Character
{
    public struct OrientationComponent
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
    }
}