using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    internal class HoldButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool _isHold;

        public bool IsHold => _isHold;

        public void OnPointerDown(PointerEventData eventData) => _isHold = true;
        public void OnPointerUp(PointerEventData eventData) => _isHold = false;
    }
}

