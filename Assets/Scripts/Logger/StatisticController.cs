namespace Game.Statistic
{
    class StatisticController : BaseController
    {
        private readonly ILogger _logger;

        public StatisticController(GameModel gameModel, ILogger logger) : base(gameModel)
        {
            _logger = logger;
        }

        protected override void OnGameOver() => _logger.LogTryCount();
    }
}
