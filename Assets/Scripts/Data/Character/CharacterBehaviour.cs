using UnityEngine;

namespace Data.Character
{
    public class CharacterBehaviour : MonoBehaviour
    {
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
    }
}