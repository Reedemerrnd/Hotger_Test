using BallGame.Game.Ball;
using BallGame.Game.Level;
using BallGame.UI;

namespace BallGame.Utils.ResourceLoad
{
    internal interface ILoadResources
    {
        BallView LoadBallView();
        LevelView LoadLevelView();
        BaseView LoadUIView(UIType uIType);

        ObstacleView LoadObstacle();
    }
}
