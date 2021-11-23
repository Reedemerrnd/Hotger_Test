using System;

namespace Game.Utils
{
    internal interface IReadOnlySubscriptionProperty<T>
    {
        T Value { get; }

        void SubscribeOnChange(Action<T> action);
        void UnSubscribeOnChange(Action<T> action);
    }
}
