using System;
using UnityEngine;

namespace Game.Ball
{
    [RequireComponent (typeof(Collider2D))]
    internal class BallView : MonoBehaviour, IBallView
    {
        public event Action OnCollision;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnCollision?.Invoke();
        }

        public void Move(float speed) => transform.position += Vector3.down * speed * Time.deltaTime;
        public void Disable() => gameObject.SetActive(false);
        public void Enable() => gameObject.SetActive(true);
        public void SetPosition(Vector3 position) => transform.position = position;
    }
}