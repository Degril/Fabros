using UnityEngine;

namespace Services.Both.CharacterMovement
{
    public interface IInput
    {
        bool IsFireButtonPressed(out Vector3 targetPosition);
    }
}