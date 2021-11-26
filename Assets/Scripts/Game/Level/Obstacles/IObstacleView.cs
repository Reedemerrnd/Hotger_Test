using UnityEngine;

namespace BallGame.Game.Level
{
    interface IObstacleView : INotifyDisable, IMovingView
    {
        void SetPosition(Vector3 position);
        void SetXBorderToDisable(float X);
    }
}
