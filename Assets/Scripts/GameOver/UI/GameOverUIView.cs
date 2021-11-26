using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BallGame.UI
{
    internal sealed class GameOverUIView : BaseView
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _setDifficultyButton;

        [SerializeField] private Text _lastTryLengthText;
        [SerializeField] private Text _tryCountText;


        public void Init(UnityAction restartHandler, UnityAction setDifficultyHandler)
        {
            _restartButton.onClick.AddListener(restartHandler);
            _setDifficultyButton.onClick.AddListener(setDifficultyHandler);
        }

        public void DisplayLength(string length) => _lastTryLengthText.text = "Продолжительность попытки: " + length;

        public void DisplayTryCount(string count) => _tryCountText.text = "Общее количество попыток: " + count;

        private void OnDisable()
        {
            _restartButton.onClick.RemoveAllListeners();
            _setDifficultyButton.onClick.RemoveAllListeners();
        }
    }
}

