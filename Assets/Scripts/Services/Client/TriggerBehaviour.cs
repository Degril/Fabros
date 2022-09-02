using Data.Character;
using UnityEngine;

namespace Services.Client
{
    public class TriggerBehaviour : MonoBehaviour
    {
        public bool IsTriggered { get; private set; }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CharacterBehaviour>(out var _))
            {
                IsTriggered = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<CharacterBehaviour>(out var _))
            {
                IsTriggered = false;
            }
        }
    }
}
