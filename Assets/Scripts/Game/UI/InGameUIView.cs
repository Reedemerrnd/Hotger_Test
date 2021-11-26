using System;
using UnityEngine;

namespace BallGame.Game.UI
{
    internal class InGameUIView : BaseView
    {
        [SerializeField] private HoldButtonHandler _upButton;

        public void SubscribeOnButtonChange(Action<bool> buttonHandler) => _upButton.OnButtonHold += buttonHandler;
        public void UnSubscribeOnButtonChange(Action<bool> buttonHandler) => _upButton.OnButtonHold -= buttonHandler;
    }
}

