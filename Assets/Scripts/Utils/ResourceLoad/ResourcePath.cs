using BallGame.UI;
using System.Collections.Generic;

namespace BallGame.Utils.ResourceLoad
{
    internal static class ResourcePath
    {
        public static Dictionary<UIType, string> UI = new Dictionary<UIType, string>()
        {
            {UIType.InGame, $"UI/{UIType.InGame}" },
            {UIType.MainMenu, $"UI/{UIType.MainMenu}" },
            {UIType.GameOverMenu, $"UI/{UIType.GameOverMenu}" },
        };

        public static string ObstaclePrefab = "Level/Obstacle";
        public static string BallPrefab = "Ball/BallView";
        public static string LevelPrefab = "Level/LevelView";
        public static string StatisticFile = "Statistic";
    }

}