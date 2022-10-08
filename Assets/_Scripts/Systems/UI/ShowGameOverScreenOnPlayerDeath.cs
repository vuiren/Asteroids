using _Scripts.Systems;

namespace _Scripts.MonoLinks.Objects.UI
{
    public class ShowGameOverScreenOnPlayerDeath : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public ShowGameOverScreenOnPlayerDeath(GameEntitiesBag gameEntitiesBag)
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

            if (!player.markedForDestroying) return;

            gameOverScreen.gameOverScreenUI.SetActive(true);
            gameOverScreen.scoreText.text = "Score: " + score.score;
        }
    }
}