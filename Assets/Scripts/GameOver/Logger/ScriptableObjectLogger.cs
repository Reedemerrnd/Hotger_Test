namespace BallGame.Statistic
{
    internal sealed class ScriptableObjectLogger : ILogger
    {
        private readonly GameStatictics _gameStatictics;


        public ScriptableObjectLogger(GameStatictics gameStatictics)
        {
            _gameStatictics = gameStatictics;
        }


        public void LogTryCount() => _gameStatictics.TotalTryCount++;
    }
}
