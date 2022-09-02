using UnityEngine;

namespace Services.Both.CharacterMovement
{
    public interface IMover
    {
        Vector3 CurrentPosition { get; }

        void MoveTo(Vector3 targetPosition);
    }
}