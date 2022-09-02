using System;
using Services.Both.CharacterMovement;
using UnityEngine;

namespace Components.Client.CharacterMovement
{
    [Serializable]
    public struct TransformComponent
    {
        [field: SerializeField] public CharacterController CharacterController { get; set; }
        [field: SerializeField] public Transform Transform { get; set; }

        public Vector3 CurrentPosition => Transform.position;
        public void MoveTo(Vector3 targetPosition)
        {
            const float speed = 1f;
            var direction = (targetPosition - CurrentPosition).normalized;
            var singleStep = speed * Time.deltaTime;
            
            var newDirection = Vector3.RotateTowards(Transform.forward, direction, singleStep, 0.0f);
            Transform.rotation = Quaternion.LookRotation(newDirection);

            if(Vector3.Dot(Transform.forward, direction) > 0.8f)
                CharacterController.Move(targetPosition);
        }
    }
}
