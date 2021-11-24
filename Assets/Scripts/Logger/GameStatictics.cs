using UnityEngine;

namespace Game.Statistic
{
    [CreateAssetMenu(menuName = "Game/Statistics")]
    internal class GameStatictics : ScriptableObject, IReadOnlyStatistics
    {
        private int _totalTryCount = 0;

        public int TotalTryCount { get => _totalTryCount; set => _totalTryCount = value; }
    }
}
