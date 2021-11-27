using System;
using UnityEngine;

namespace BallGame.Game.Ball
{
    [RequireComponent (typeof(Collider2D))]
    internal class BallView : BaseView, IBallView
    {
        public event Action OnCollision;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnCollision?.Invoke();
        }


        public void Move(float speed) => transform.position += Vector3.down * speed * Time.deltaTime;
        public void SetPosition(Vector3 position) => transform.position = position;
    }
}