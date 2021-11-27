using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BallGame.Game.UI
{
    internal sealed class HoldButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action<bool> OnButtonHold;


        private void OnEnable()
        {
            OnButtonHold?.Invoke(false);
        }


        public void OnPointerDown(PointerEventData eventData) => OnButtonHold?.Invoke(true);
        public void OnPointerUp(PointerEventData eventData) => OnButtonHold?.Invoke(false);
    }
}

