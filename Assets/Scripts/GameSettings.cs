using UnityEngine;

namespace BallGame
{
    [CreateAssetMenu(menuName = "Game/Settings")]
    internal class GameSettings : ScriptableObject
    {

        [Header("Settings")]
        [SerializeField] private GameState _initialState;
        [SerializeField] private float _baseVerticalSpeed;
        [SerializeField] private float _baseHorizontalSpeed;
        [SerializeField] private float _speedIncreaseDelay;
        [SerializeField, Range(1.1f, 2f)] private float _speedIncreaseRate;
        [SerializeField] private Vector3 _ballSpawnPosition;

        [Header("Difficulty speed modifiers")]
        [SerializeField, Range(0.3f, 0.8f)] private float _easyModifier;
        [SerializeField, Range (0.8f, 1.3f)] private float _mediumModifier;
        [SerializeField, Range(1.3f, 1.8f)] private float _hardModifier;

        [Header("Obstacles")]
        [SerializeField] private float _obstacleSpawnRate;

        public GameState InitialState => _initialState;
        public float BaseVerticalSpeed => _baseVerticalSpeed;
        public float BaseHorizontalSpeed => _baseHorizontalSpeed;
        public float SpeedIncreaseDelay => _speedIncreaseDelay;
        public float SpeedIncreaseRate => _speedIncreaseRate;
        public Vector3 BallSpawnPosition => _ballSpawnPosition;

        public float EasyModifier => _easyModifier;
        public float MediumModifier => _mediumModifier;
        public float HardModifier => _hardModifier;

        public float ObstacleSpawnRate => _obstacleSpawnRate;
    }

}