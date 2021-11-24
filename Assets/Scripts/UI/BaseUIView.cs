using UnityEngine;

namespace Game.UI
{
    internal abstract class BaseUIView : MonoBehaviour, IObjectView
    {
        public virtual void Disable() => gameObject.SetActive(false);
        public virtual void Enable() => gameObject.SetActive(true);
    }
}
