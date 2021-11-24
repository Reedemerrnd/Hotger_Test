using Game.Ball;
using Game.Level;
using Game.UI;
using UnityEngine;

namespace Game.ResourcesLoader
{
    internal interface ILoadResources
    {
        IBallView GetBallView(Vector3 position);
        ILevelView GetLevelVIew();
        BaseUIView GetUIView(UIType uIType);
    } 
}
