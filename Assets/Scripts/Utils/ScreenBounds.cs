using UnityEngine;

namespace BallGame.Utils.Screen
{
    internal sealed class ScreenBounds
    {
        private readonly Vector3 _bottomLeft;
        private readonly Vector3 _topRight;
        private readonly float _width;
        private readonly float _height;

        public Vector3 TopRight => _topRight;
        public Vector3 BottomLeft => _bottomLeft;
        public float Width => _width;
        public float Height => _height;

        
        public ScreenBounds()
        {
            var camera = Camera.main;
            _topRight = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, camera.depth));
            _bottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.depth));
            _width = _topRight.x - _bottomLeft.x;
            _height = _topRight.y - _bottomLeft.y;
        }
    }
}
