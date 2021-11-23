using Game.Utils;

namespace Game.Level
{
    internal interface ILevelView : ILevelObjectView
    {
        void Construct(ScreenBounds screenBounds);
    }
}
