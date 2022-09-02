using UnityEngine;

namespace Services.Client.CharacterMovement
{
    public interface IInput
    {
        bool IsFireButtonPressed(out Vector3 targetPosition);
    }
}