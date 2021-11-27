using BallGame.Game.Ball;
using BallGame.Game.Level;
using BallGame.Game.UI;
using BallGame.UI;
using BallGame.Utils;
using BallGame.Utils.ResourceLoad;
using UnityEngine;

using Object = UnityEngine.Object;

namespace BallGame
{
    internal sealed class Factory : IGameFactory, IUIFactory
    {
        private readonly ILoadResources _resourceLoader;

        public Factory(ILoadResources resourceLoader)
        {
            _resourceLoader = resourceLoader;
        }


        public BallView CreateBallView(Vector3 position = default(Vector3))
        {
            var prefab = _resourceLoader.LoadBallView();
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }

        public LevelView CreateLevelView()
        {
            var prefab = _resourceLoader.LoadLevelView();
            return Object.Instantiate(prefab);
        }

        public MainMenuUIView CreateMainMenu()
        {
            var prefab = _resourceLoader.LoadUIView(UIType.MainMenu).GetComponent<MainMenuUIView>();
            return Object.Instantiate(prefab);
        }

        public GameOverUIView CreateGameOverMenu()
        {
            var prefab = _resourceLoader.LoadUIView(UIType.GameOverMenu).GetComponent<GameOverUIView>();
            return Object.Instantiate(prefab);
        }

        public InGameUIView CreateInGameUI()
        {
            var prefab = _resourceLoader.LoadUIView(UIType.InGame).GetComponent<InGameUIView>();
            return Object.Instantiate(prefab);
        }

        public IPool<IObstacleView> CreateObstaclePool()
        {
            var prefab = _resourceLoader.LoadObstacle();
            return new Pool<IObstacleView>(prefab);
        }
    }
}
