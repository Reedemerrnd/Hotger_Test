using System;
using UnityEngine;

namespace Game.Ball
{
    [RequireComponent (typeof(Collider2D))]
    internal class BallView : MonoBehaviour, IBallView
    {
        private event Action OnCollision = () => { };


        private void OnTriggerEnter2D(Collider2D collision) => OnCollision();

        private void OnDestroy() => OnCollision = () => { };


        public void Construct(Action OnCollisionHandler) => OnCollision += OnCollisionHandler;
        public void Move(float speed) => transform.position += Vector3.down * speed * Time.deltaTime;
        public void Destroy() => Destroy(gameObject);
    }
}