using BallGame.Game.Level;
using UnityEngine;

namespace BallGame.Utils
{
    internal interface IPool<T> where T : MonoBehaviour, INotifyDisable
    {
        T GetItem();
    }
}
