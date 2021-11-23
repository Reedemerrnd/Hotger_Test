using Game.Utils;
using UnityEngine;

namespace Game.Level
{
    internal class LevelView : MonoBehaviour, ILevelView
    {

        public Transform[] Tiles;
        public float Speed;

        private float _leftXOffset;
        private float _rightXOffset;

        public void Construct(ScreenBounds screenBounds)
        {
            _leftXOffset = screenBounds.BottomLeft.x - screenBounds.Width / 2;
            _rightXOffset = screenBounds.TopRight.x + screenBounds.Width / 2;
        }

        private void MoveTile(Transform tile, float speed)
        {
            var position = tile.position;
            position += Vector3.left * Speed * Time.deltaTime;
            if (position.x <= _leftXOffset)
            {
                position.x = _rightXOffset;
            }
            tile.position = position;
        }

        public void Move(float speed)
        {
            foreach (var tile in Tiles)
            {
                MoveTile(tile, Speed);
            }
        }

        public void Destroy() => Destroy(gameObject);
    } 
}

