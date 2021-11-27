using UnityEngine;

namespace BallGame.Game.Level
{
    internal interface IPrototype<T>
    {
        T Clone();
    }

}
