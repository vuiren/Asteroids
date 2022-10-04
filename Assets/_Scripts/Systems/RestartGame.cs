using _Scripts.Data;
using _Scripts.Factories;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class RestartGame : IRunSystem
    {
        private readonly Configuration _configuration;
        private readonly GameEntitiesBag _gameEntitiesBag;
        private readonly FlyingEntitiesFactory _flyingEntitiesFactory;

        public RestartGame(Configuration configuration, GameEntitiesBag gameEntitiesBag, FlyingEntitiesFactory flyingEntitiesFactory)
        {
            _configuration = configuration;
            _gameEntitiesBag = gameEntitiesBag;
            _flyingEntitiesFactory = flyingEntitiesFactory;
        }

        public void Run()
        {
            if (_gameEntitiesBag.restartGames.Length == 0) return;
            var restartGame = _gameEntitiesBag.restartGames[0];

            if (_gameEntitiesBag.playerSpawnPoints.Length == 0) return;
            var playerSpawnPoint = _gameEntitiesBag.playerSpawnPoints[0];

            if(_gameEntitiesBag.gameOverScreens.Length == 0) return;
            var gameOverScreen = _gameEntitiesBag.gameOverScreens[0];
            
            if(_gameEntitiesBag.scores.Length == 0) return;
            var score = _gameEntitiesBag.scores[0];
            
            if (!restartGame.gameRestarting) return;

            foreach (var asteroidsSpawner in _gameEntitiesBag.asteroidsSpawners)
            {
                asteroidsSpawner.RemainingDelayBeforeAsteroidSpawn = -1;
                asteroidsSpawner.active = true;
            }

            score.score = 0;

            _flyingEntitiesFactory.Create(_configuration.PlayerPrefab, playerSpawnPoint.transform);

            restartGame.gameRestarting = false;
            gameOverScreen.gameOverScreenUI.SetActive(false);
        }
    }
}