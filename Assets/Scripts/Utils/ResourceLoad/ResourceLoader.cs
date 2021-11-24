using Game.Ball;
using Game.Level;
using Game.UI;
using Game.Statistic;
using UnityEngine;

namespace Game.ResourcesLoader
{
    internal class ResourceLoader : ILoadResources
    {
        public IBallView GetBallView(Vector3 position) => LoadAndInstantiate<BallView, IBallView>(ResourcePath.BallPrefab);

        public ILevelView GetLevelVIew() => LoadAndInstantiate<LevelView, ILevelView>(ResourcePath.LevelPrefab);

        public BaseUIView GetUIView(UIType uIType) => LoadAndInstantiate<BaseUIView, BaseUIView>(ResourcePath.UI[uIType]);

        public GameStatictics GetStatisticFile() => Resources.Load<GameStatictics>(ResourcePath.StatisticFile); 

        private Treturn LoadAndInstantiate<Tload, Treturn>(string path, Vector3 position = default(Vector3)) where Tload : MonoBehaviour
        {
            var prefab = Resources.Load<Tload>(path);
            var obj = Object.Instantiate(prefab);
            return obj.GetComponent<Treturn>();
        }

    }
}
