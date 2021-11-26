using System;
using UnityEngine;

namespace BallGame.Game.Level
{
    internal interface INotifyDisable
    {
        event Action<INotifyDisable> OnDeactivation;
    }
}