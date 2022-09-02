using Data.Character;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = nameof(DataProvider), menuName = "Data/" + nameof(DataProvider))]
    public class DataProvider : ScriptableObject
    {
        private static DataProvider _instance;
        public static DataProvider Instance => _instance ??= Resources.Load<DataProvider>("DataProvider");
        
        [field: SerializeField] public CharacterBehaviour CharacterBehaviour { get; private set; }
    }
}
