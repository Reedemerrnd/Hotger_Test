using System;
using UnityEngine;

namespace BallGame.Level
{
    internal class ObstacleView : MonoBehaviour, IMovingView, IObjectView
    {



        public void Disable() => gameObject.SetActive(false);
        public void Enable() => gameObject.SetActive(true);
        public void Move(float speed) => transform.position += Vector3.left * speed * Time.deltaTime;
    }
}