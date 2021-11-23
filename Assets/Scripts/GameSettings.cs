using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Settings")]
    internal class GameSettings : ScriptableObject, IPrefabContainer
    {
        [field: Header ("Settings")]
        [field: SerializeField] public GameState InitialState { get; private set; }

        [field: SerializeField] public float BaseVerticalSpeed { get; private set; }
        [field: SerializeField] public float BaseHorizontalSpeed { get; private set; }
        [field: SerializeField] public float SpeedIncreaseDelay { get; private set; }
        [field: SerializeField] public Vector3 BallSpawnPosition { get; private set; }


        [field: Header("Difficulty speed modifiers")]
        [field: SerializeField] public float EasyModifier { get; private set; }
        [field: SerializeField] public float MediumModifier { get; private set; }
        [field: SerializeField] public float HardModifier { get; private set; }

        [field: Header("Prefabs")]
        [field: SerializeField] public GameObject BallPrefab { get; private set; }
        [field: SerializeField] public GameObject LevelPrefab { get; private set; }
    }

}