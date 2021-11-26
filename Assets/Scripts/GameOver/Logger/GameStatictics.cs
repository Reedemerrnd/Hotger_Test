using UnityEngine;

namespace BallGame.Statistic
{
    [CreateAssetMenu(menuName = "Game/Statistics")]
    internal class GameStatictics : ScriptableObject, IReadOnlyStatistics
    {
        private int _totalTryCount;

        public int TotalTryCount { get => _totalTryCount; set => _totalTryCount = value; }
    }
}
