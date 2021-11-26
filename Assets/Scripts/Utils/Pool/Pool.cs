using BallGame.Game.Level;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BallGame.Utils
{
    internal sealed class Pool<T> : IPool<T> where T : MonoBehaviour, INotifyDisable
    {
        private T _prefab;
        private Stack<INotifyDisable> _pool;


        public Pool(T prefab)
        {
            _pool = new Stack<INotifyDisable>();
            _prefab = prefab;
        }

        private void ReturnToPool(INotifyDisable gameObject)
        {
            gameObject.OnDeactivation -= ReturnToPool;
            _pool.Push(gameObject);
        }

        public T GetItem()
        {
            T item;
            if (_pool.Count > 0)
            {
                item = _pool.Pop() as T;
            }
            else
            {
                item = Object.Instantiate(_prefab);
            }
            item.OnDeactivation += ReturnToPool;
            return item;
        }
    }
}
