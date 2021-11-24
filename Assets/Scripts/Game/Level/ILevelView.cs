using Game.Utils;

namespace Game.Level
{
    internal interface ILevelView : IMovingView, IObjectView
    {
        void Construct(ScreenBounds screenBounds);
    }
}
