using UnityEngine;

namespace Components.Client.CharacterMovement
{
    internal struct MainCharacterComponent
    {
        internal CharacterController CharacterController { get; set; }
        internal Transform Transform { get; set; }
    }
}
