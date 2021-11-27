using UnityEngine;
using UnityEngine.Tilemaps;

namespace BallGame.Game.Level
{
    internal class LevelView : BaseView, ILevelView
    {

        [SerializeField] private Transform[] _tiles;
        private float _leftXOffset;
        private float _rightXOffset;



        public void Construct(float XToDespawn, float XToSpawn)
        {
            _leftXOffset = XToDespawn;
            _rightXOffset = XToSpawn;
        }

        private void MoveTile(Transform tile, float speed)
        {
            var position = tile.position;
            position += Vector3.left * speed * Time.deltaTime;
            if (position.x <= _leftXOffset)
            {
                position.x = _rightXOffset;
            }
            tile.position = position;
        }

        public void Move(float speed)
        {
            foreach (var tile in _tiles)
            {
                MoveTile(tile, speed);
            }
        }

        public (float YTop, float YBottom) GetCorridorBounds()
        {
            var tilemap = GetTilemap();
            if(tilemap != null)
            {
                return (tilemap.localBounds.max.y, tilemap.localBounds.min.y);
            }
            return (0f, 0f);
        }

        public Tilemap GetTilemap()
        {
            if (_tiles[0].TryGetComponent<Tilemap>(out var tilemap))
            {
                return tilemap;
            }
            return null;
        }

    }
}

