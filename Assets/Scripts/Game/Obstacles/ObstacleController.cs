using BallGame.Game.Level;
using BallGame.Utils;
using BallGame.Utils.Screen;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace BallGame.Game
{
    internal sealed class ObstacleController : BaseController
    {
        private readonly IPool<IObstacleView> _obstaclePool;
        private readonly GameModel _gameModel;
        private readonly ILevelView _levelView;
        private readonly ScreenBounds _screenBounds;
        private readonly UpdateManager _updateManager;

        private float _xToDeactivate;
        private float _xToActivate;
        private int _upperBound;
        private int _lowerBound;
        private float _nextSpawnTime;

        private List<IObstacleView> _activeObstacles;


        public ObstacleController(IPool<IObstacleView> obstaclePool, GameModel gameModel, ILevelView levelView, ScreenBounds screenBounds, UpdateManager updateManager)
        {
            _obstaclePool = obstaclePool;
            _gameModel = gameModel;
            _levelView = levelView;
            _screenBounds = screenBounds;
            _updateManager = updateManager;

            _activeObstacles = new List<IObstacleView>();
            _nextSpawnTime = Time.time;

            CalculateBounds();
        }


        private void CalculateBounds()
        {
            var tilemap = _levelView.GetTilemap();
            _upperBound = (int)(tilemap.localBounds.max.y - tilemap.cellSize.y);
            _lowerBound = (int)(tilemap.localBounds.min.y + tilemap.cellSize.y);

            _xToDeactivate = _screenBounds.BottomLeft.x - tilemap.cellSize.x;
            _xToActivate = _screenBounds.TopRight.x + tilemap.cellSize.x;
        }


        private void HandleUpdate()
        {
            TrySpawnObstacle();

            foreach (var obstacle in _activeObstacles)
            {
                obstacle.Move(_gameModel.HorizontalSpeed);
            }
        }

        private void TrySpawnObstacle()
        {
            if (CheckTimer())
            {
                var obstacle = _obstaclePool.GetItem();
                var position = GetRandomPosition();

                obstacle.Enable();
                obstacle.SetPosition(position);
                obstacle.SetXBorderToDisable(_xToDeactivate);
                obstacle.OnDeactivation += ObstacleDectivateHandler;

                _activeObstacles.Add(obstacle);
            }
        }

        private void ObstacleDectivateHandler(IObstacleView obj)
        {
            obj.OnDeactivation -= ObstacleDectivateHandler;
            _activeObstacles.Remove(obj);
        }

        private Vector3 GetRandomPosition()
        {
            int Y = Random.Range(_lowerBound, _upperBound);
            return new Vector3(_xToActivate, Y, 0f);
        }

        private bool CheckTimer()
        {
            if (Time.time >= _nextSpawnTime)
            {
                _nextSpawnTime += _gameModel.ObstacleSpawnDelay;
                return true;
            }
            return false;
        }


        protected override void OnEnable() => _updateManager.SubscribeOnUpdate(HandleUpdate);
        protected override void OnDisable()
        {
            _updateManager.UnSubscribeOnUpdate(HandleUpdate);

            foreach (var obstacle in _activeObstacles)
            {
                obstacle.OnDeactivation -= ObstacleDectivateHandler;
                obstacle.Disable();
            }
            _activeObstacles.Clear();
        }
    }
}
