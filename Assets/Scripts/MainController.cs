using Game.Ball;
using Game.GameTimer;
using Game.Level;
using Game.ResourcesLoader;
using Game.Utils;
using Game.UI;
using System.Collections.Generic;
using UnityEngine;
using Game.Statistic;

namespace Game
{
    internal class MainController : MonoBehaviour
    {
        private List<IDoUpdate> _updates;

        [field: SerializeField] public GameSettings Settings { get; private set; }


        private void Awake()
        {
            _updates = new List<IDoUpdate>();
            var gameModel = new GameModel(Settings);
            var screenBounds = new ScreenBounds();
            var resourceLoader = new ResourceLoader();

            var statisticFile = resourceLoader.GetStatisticFile();
            var logger = new ScriptableObjectLogger(statisticFile);
            var statsCintroller = new StatisticController(gameModel, logger);

            var ballController = new BallController(gameModel, resourceLoader);
            _updates.Add(ballController);

            var levelController = new LevelController(gameModel,resourceLoader, screenBounds);
            _updates.Add(levelController);

            var gameTimeController = new GameTimerController(gameModel);
            _updates.Add(gameTimeController);

            var UIController = new UIController(gameModel, resourceLoader, statisticFile);
            _updates.Add(UIController);

            gameModel.State.Value = Settings.InitialState;
        }

        private void Update()
        {
            foreach (var controller in _updates)
            {
                controller.DoUpdate();
            }
        }
    }
}
