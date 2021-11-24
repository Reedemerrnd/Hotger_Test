using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    internal sealed class MainMenuUIView : BaseUIView
    {
        [SerializeField] private Toggle _easyToggle;
        [SerializeField] private Toggle _mediumToggle;
        [SerializeField] private Toggle _hardToggle;
        [SerializeField] private Button _startButton;

        private GameDifficulty _selectedDifficulty;

        public event Action<GameDifficulty> OnGameStart = (d) => { };

        private void OnEnable()
        {
            _startButton.onClick.AddListener(HandleStartButton);
        }

        private void OnDisable()
        {
            OnGameStart = (d) => { };
            _startButton.onClick.RemoveListener(HandleStartButton);
        }

        private void HandleStartButton()
        {
            if (_easyToggle.isOn)
            {
                _selectedDifficulty = GameDifficulty.Easy;
            }
            else if (_mediumToggle.isOn)
            {
                _selectedDifficulty = GameDifficulty.Medium;
            }
            else
            {
                _selectedDifficulty = GameDifficulty.Hard;
            }

            OnGameStart?.Invoke(_selectedDifficulty);
        }
    }
}
