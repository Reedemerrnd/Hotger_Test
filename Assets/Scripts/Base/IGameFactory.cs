using BallGame.Game.Ball;
using BallGame.Game.Level;
using UnityEngine;

namespace BallGame
{
    internal interface IGameFactory
    {
        BallView CreateBallView(Vector3 position);
        LevelView CreateLevelView();
    }
}
