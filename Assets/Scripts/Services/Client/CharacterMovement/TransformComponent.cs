using System;
using UnityEngine;

namespace Services.Client.CharacterMovement
{
    [Serializable]
    public struct TransformComponent
    {
        [field: SerializeField] public Transform Transform { get; set; }
    }
}
