using BallGame.Statistic;

namespace BallGame.UI
{
    internal sealed class GameOverUIController : BaseController
    {
        private readonly IReadOnlyStatistics _gameStats;
        private readonly GameModel _gameModel;
        private readonly GameOverUIView _gameOverUIView;


        public GameOverUIController(GameModel gameModel, GameOverUIView gameOverUIView, IReadOnlyStatistics gameStats)
        {
            _gameStats = gameStats;
            _gameModel = gameModel;
            _gameOverUIView = gameOverUIView;
        }


        protected override void OnEnable()
        {
            _gameOverUIView.DisplayLength(_gameModel.CurrentRunTime.SecondsToTimeString());
            _gameOverUIView.DisplayTryCount(_gameStats.TotalTryCount.ToString());

            _gameOverUIView.Init(RestartHandler, DifficultyChangeHandler);
        }


        private void RestartHandler()
        {
            _gameModel.ResetSameDifficulty();
            _gameModel.SetState(GameState.Game);
        }

        private void DifficultyChangeHandler()
        {
            _gameModel.SetState(GameState.MainMenu);
        }
    }
}
