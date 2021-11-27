namespace BallGame.Utils
{
    internal interface IPool<T> where T : IPrototype<T>, IDisablable, INotifyDisable<T>
    {
        T GetItem();
    }
}
