using BallGame.Game.Ball;
using BallGame.Game.Level;
using BallGame.Utils;
using UnityEngine;

namespace BallGame
{
    internal interface IGameFactory
    {
        BallView CreateBallView(Vector3 position);
        LevelView CreateLevelView();
        IPool<IObstacleView> CreateObstaclePool();
    }
}
