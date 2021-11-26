using System.Collections.Generic;

namespace BallGame
{
    internal abstract class BaseController : IDisablable
    {
        private List<IDisablable> _disablalbles;

        private void EnableObjects()
        {
            if (_disablalbles == null)
                return;

            foreach (IDisablable disablable in _disablalbles)
                disablable.Enable();
        }

        private void DisableObjects()
        {
            if (_disablalbles == null)
                return;

            foreach (IDisablable disablable in _disablalbles)
                disablable.Disable();
        }

        protected void AddDisablable(IDisablable disablebleObj)
        {
            if(_disablalbles == null)
            {
                _disablalbles = new List<IDisablable>();
            }
            _disablalbles.Add(disablebleObj);
        }

        public void Disable()
        {
            OnDisable();
            DisableObjects();
        }

        protected virtual void OnDisable() { }

        public void Enable()
        {
            OnEnable();
            EnableObjects();
        }

        protected virtual void OnEnable() { }
    }
}