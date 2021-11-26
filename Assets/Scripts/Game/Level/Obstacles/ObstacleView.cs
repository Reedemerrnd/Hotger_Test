﻿using System;
using UnityEngine;

namespace BallGame.Game.Level
{
    internal class ObstacleView : BaseView, IObstacleView
    {
        private float _xBorder;

        public event Action<INotifyDisable> OnDeactivation;

        public void Move(float speed)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if(transform.position.x <= _xBorder)
            {
                Disable();
            }
        }

        public void SetPosition(Vector3 position) => transform.position = position;
        public void SetXBorderToDisable(float X) => _xBorder = X;

        public override void Disable()
        {
            OnDeactivation?.Invoke(this);
            base.Disable();
        }
    }
}