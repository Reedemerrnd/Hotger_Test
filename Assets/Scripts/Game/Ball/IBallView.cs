using System;
using UnityEngine;

namespace BallGame.Game.Ball
{
    internal interface IBallView : IMovingView
    {
        event Action OnCollision;
        void SetPosition(Vector3 position);
    }
}