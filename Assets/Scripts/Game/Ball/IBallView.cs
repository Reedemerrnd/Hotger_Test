using System;
using UnityEngine;

namespace Game.Ball
{
    internal interface IBallView : IMovingView, IObjectView
    {
        event Action OnCollision;
        void SetPosition(Vector3 position);
    }
}