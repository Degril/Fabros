using Services.Both;
using Services.Both.CharacterMovement;
using Services.Client.CharacterMovement;
using UnityEngine;

namespace Services.Client
{
    public class ClientServices : IServices
    {
        public ClientServices()
        {
            var camera = Camera.main;
            Input = new PlayerInput(camera);
        }

        public IInput Input { get; }
    }
}