using _Scripts.MonoLinks;

namespace _Scripts.Systems.UI
{
    public class RestartGameButtonHandler : IStartSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public RestartGameButtonHandler(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Start()
        {
            if (_gameEntitiesBag.gameOverScreens.Length == 0) return;
            var gameOverScreen = _gameEntitiesBag.gameOverScreens[0];

            gameOverScreen.restartButton.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            if (_gameEntitiesBag.restartGames.Length == 0) return;
            var restartGame = _gameEntitiesBag.restartGames[0];

            restartGame.gameRestarting = true;

            foreach (var flyingEntity in _gameEntitiesBag.flyingEntities) flyingEntity.MarkedForDestroying = true;

            foreach (var asteroidsSpawner in _gameEntitiesBag.asteroidsSpawners) asteroidsSpawner.active = false;
        }
    }
}