using BallGame.Game.Level;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BallGame.Utils
{
    internal sealed class Pool<T> : IPool<T> where T : IPrototype<T>, IDisablable, INotifyDisable<T>
    {
        private T _prefab;
        private Stack<T> _pool;


        public Pool(T prefab)
        {
            _pool = new Stack<T>();
            _prefab = prefab;
        }

        private void ReturnToPool(T gameObject)
        {
            gameObject.OnDeactivation -= ReturnToPool;
            _pool.Push(gameObject);
        }

        public T GetItem()
        {
            T item;
            if (_pool.Count > 0)
            {
                item = _pool.Pop();
            }
            else
            {
                item = _prefab.Clone();
            }
            item.OnDeactivation += ReturnToPool;
            return item;
        }
    }
}
