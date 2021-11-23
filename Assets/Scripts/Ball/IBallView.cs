using System;

namespace Game.Ball
{
    internal interface IBallView : ILevelObjectView
    {
        void Construct(Action OnCollisionHandler);
    }
}