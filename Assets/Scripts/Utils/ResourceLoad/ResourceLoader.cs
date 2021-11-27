using BallGame.Game.Ball;
using BallGame.Game.Level;
using BallGame.Statistic;
using BallGame.UI;
using UnityEngine;

namespace BallGame.Utils.ResourceLoad
{
    internal class ResourceLoader : ILoadResources
    {
        public BallView LoadBallView() => Resources.Load<BallView>(ResourcePath.BallPrefab);

        public LevelView LoadLevelView() => Resources.Load<LevelView>(ResourcePath.LevelPrefab);

        public BaseView LoadUIView(UIType uIType) => Resources.Load<BaseView>(ResourcePath.UI[uIType]);

        public GameStatictics LoadStatsFile() => Resources.Load<GameStatictics>(ResourcePath.StatisticFile);

        public ObstacleView LoadObstacle() => Resources.Load<ObstacleView>(ResourcePath.ObstaclePrefab);
    }
}
