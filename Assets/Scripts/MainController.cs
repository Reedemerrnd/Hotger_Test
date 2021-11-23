using Game.Ball;
using Game.Level;
using Game.Utils;
using System.Collections.Generic;
using UnityEngine;

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

            var ballController = new BallController(gameModel, Settings);
            _updates.Add(ballController);

            var levelController = new LevelController(gameModel, Settings, screenBounds);
            _updates.Add(levelController);


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
