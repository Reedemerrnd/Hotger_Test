using System;

namespace BallGame.Game.Level
{
    internal interface INotifyDisable<T>
    {
        event Action<T> OnDeactivation;
    }
}