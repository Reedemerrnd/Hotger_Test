using System;
using UnityEngine;

namespace BallGame
{
    internal class UpdateManager : MonoBehaviour
    {
        private Action _onUpdate;


        private void Update()
        {
            _onUpdate?.Invoke();
        }


        public void SubscribeOnUpdate(Action updateHandler) => _onUpdate += updateHandler;
        public void UnSubscribeOnUpdate(Action updateHandler) => _onUpdate -= updateHandler;
    }
}
