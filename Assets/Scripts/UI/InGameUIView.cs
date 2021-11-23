using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    internal class InGameUIView : MonoBehaviour
    {
        [SerializeField] private HoldButtonHandler _upButton;

        public bool ButtonHeld => _upButton.IsHold;
    }
}

