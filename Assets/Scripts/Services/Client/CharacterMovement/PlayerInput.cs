using Services.Both.CharacterMovement;
using UnityEngine;

namespace Services.Client.CharacterMovement
{
    public class PlayerInput : IInput
    {
        private Camera _camera;
        
        public PlayerInput(Camera camera)
        {
            _camera = camera;
        }
        public bool IsFireButtonPressed(out Vector3 targetPosition)
        {
            var isPressed = Input.GetKeyDown(KeyCode.Mouse0);
            
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            targetPosition = Physics.Raycast(ray, out var hit) ? hit.point : Vector2.zero;
            
            return isPressed;
        }
    }
}