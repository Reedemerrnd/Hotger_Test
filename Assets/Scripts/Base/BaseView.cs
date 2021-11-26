using UnityEngine;

namespace BallGame
{
    internal class BaseView : MonoBehaviour, IDisablable
    {
        public virtual void Disable() => gameObject.SetActive(false);
        public virtual void Enable() => gameObject.SetActive(true);
    }
}
