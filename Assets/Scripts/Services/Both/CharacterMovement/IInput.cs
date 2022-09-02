using UnityEngine;

namespace Services.Both.CharacterMovement
{
    public interface IInput
    {
        bool IsFireButtonPressed(out Vector2 targetPosition);
    }
}