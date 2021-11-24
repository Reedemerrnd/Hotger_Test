using UnityEngine;

namespace Game.UI
{
    internal class InGameUIView : BaseUIView
    {
        [SerializeField] private HoldButtonHandler _upButton;

        public bool ButtonHold => _upButton.IsHold;
    }
}

