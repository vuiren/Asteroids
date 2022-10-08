using _Scripts.Data;
using _Scripts.Entities.FlyingEntities;
using _Scripts.Factories;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class RestartGame : IRunSystem
    {
        private readonly Configuration _configuration;
        private readonly FlyingEntitiesFactory _flyingEntitiesFactory;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public RestartGame(Configuration configuration, GameEntitiesBag gameEntitiesBag,
            FlyingEntitiesFactory flyingEntitiesFactory)
        {
            _configuration = configuration;
            _gameEntitiesBag = gameEntitiesBag;
            _flyingEntitiesFactory = flyingEntitiesFactory;
        }

        public void Run()
        {
            if (_gameEntitiesBag.restartGames.Length == 0) return;
            var restartGame = _gameEntitiesBag.restartGames[0];

            if (_gameEntitiesBag.gameOverScreens.Length == 0) return;
            var gameOverScreen = _gameEntitiesBag.gameOverScreens[0];

            if (_gameEntitiesBag.scores.Length == 0) return;
            var score = _gameEntitiesBag.scores[0];

            if (!restartGame.gameRestarting) return;

            foreach (var asteroidsSpawner in _gameEntitiesBag.asteroidsSpawners)
            {
                asteroidsSpawner.remainingDelayBeforeSpawn = -1;
                asteroidsSpawner.active = true;
            }

            score.score = 0;

            var player = new Player
            {
                moveSpeed = _configuration.playerData.moveSpeed,
                rotationSpeed = _configuration.playerData.rotationSpeed
            };
            _flyingEntitiesFactory.Create(player, _configuration.playerPrefab, Vector2.zero, new Quaternion());

            restartGame.gameRestarting = false;
            gameOverScreen.gameOverScreenUI.SetActive(false);
        }
    }
}