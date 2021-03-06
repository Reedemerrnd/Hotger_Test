using UnityEngine;

namespace BallGame
{
    internal class GameModel
    {
        private SubscriptionProperty<GameState> _state;

        private float _baseVerticalSpeed;

        private float _easyModifier;
        private float _mediumModifier;
        private float _hardModifier;

        private GameDifficulty _selectedDifficulty;
        public IReadOnlySubscriptionProperty<GameState> State => _state;


        public float HorizontalSpeed { get; private set; }
        public float VerticalSpeed { get; set; }
        public float SpeedIncreaseDelay { get; private set; }
        public float SpeedIncreaseRate { get; private set; }

        public Vector3 BallSpawnPosition { get; private set; }

        public float CurrentRunTime { get; set; }

        public bool UpButtonHold { get; set; }

        public float ObstacleSpawnDelay { get; private set; }


        public GameModel(GameSettings gameSettings)
        {
            _state = new SubscriptionProperty<GameState>(gameSettings.InitialState);

            HorizontalSpeed = gameSettings.BaseHorizontalSpeed;
            _baseVerticalSpeed = gameSettings.BaseVerticalSpeed;

            SpeedIncreaseDelay = gameSettings.SpeedIncreaseDelay;
            SpeedIncreaseRate = gameSettings.SpeedIncreaseRate;

            BallSpawnPosition = gameSettings.BallSpawnPosition;

            _easyModifier = gameSettings.EasyModifier;
            _mediumModifier = gameSettings.MediumModifier;
            _hardModifier = gameSettings.HardModifier;

            ObstacleSpawnDelay = gameSettings.ObstacleSpawnDelay;
        }


        public void SetState(GameState gameState)
        {
            _state.Value = gameState;
        }

        private void SetDifficulty(GameDifficulty difficulty)
        {
            _selectedDifficulty = difficulty;
            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    VerticalSpeed *= _easyModifier;
                    HorizontalSpeed *= _easyModifier;
                    break;
                case GameDifficulty.Medium:
                    VerticalSpeed *= _mediumModifier;
                    HorizontalSpeed *= _mediumModifier;
                    break;
                case GameDifficulty.Hard:
                    VerticalSpeed *= _hardModifier;
                    HorizontalSpeed *= _hardModifier;
                    break;
                default:
                    break;
            }
        }

        public void ResetSameDifficulty()
        {
            Reset(_selectedDifficulty);
        }

        public void Reset(GameDifficulty difficulty)
        {
            VerticalSpeed = _baseVerticalSpeed;
            SetDifficulty(difficulty);
        }

    }
}