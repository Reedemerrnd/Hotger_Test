using System;
using UnityEngine;

namespace BallGame.Game.Level
{
    interface IObstacleView : INotifyDisable<IObstacleView>, IMovingView, IDisablable, IPrototype<IObstacleView>
    {
        void SetPosition(Vector3 position);
        void SetXBorderToDisable(float X);
    }

}
