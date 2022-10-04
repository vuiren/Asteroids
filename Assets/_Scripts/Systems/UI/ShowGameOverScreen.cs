using _Scripts.Systems;

namespace _Scripts.MonoLinks.Objects.UI
{
    public class ShowGameOverScreen : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public ShowGameOverScreen(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            if (_gameEntitiesBag.players.Length == 0) return;
            var player = _gameEntitiesBag.players[0];

            if (_gameEntitiesBag.gameOverScreens.Length == 0) return;
            var gameOverScreen = _gameEntitiesBag.gameOverScreens[0];

            if (_gameEntitiesBag.scores.Length == 0) return;
            var score = _gameEntitiesBag.scores[0];

            if (!player.MarkedForDestroying) return;

            gameOverScreen.gameOverScreenUI.SetActive(true);
            gameOverScreen.score.text = "Score: " + score.score;
        }
    }
}