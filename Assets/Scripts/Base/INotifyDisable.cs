using System;

namespace BallGame
{
    internal interface INotifyDisable<T>
    {
        event Action<T> OnDeactivation;
    }
}