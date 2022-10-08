using _Scripts.Data;
using _Scripts.Entities.FlyingEntities;
using _Scripts.Factories;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class SpawnAsteroids : IRunSystem
    {
        private readonly Configuration _configuration;
        private readonly FlyingEntitiesFactory _flyingEntitiesFactory;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public SpawnAsteroids(Configuration configuration, FlyingEntitiesFactory flyingEntitiesFactory,
            GameEntitiesBag gameEntitiesBag)
        {
            _configuration = configuration;
            _gameEntitiesBag = gameEntitiesBag;
            _flyingEntitiesFactory = flyingEntitiesFactory;
        }

        public void Run()
        {
            foreach (var asteroidsSpawner in _gameEntitiesBag.asteroidsSpawners)
            {
                var spawnPositions = _configuration.asteroidSpawnPositions;
                if (spawnPositions.Length == 0) continue;
                if (asteroidsSpawner.remainingDelayBeforeSpawn > 0) continue;
                if (!asteroidsSpawner.active) continue;

                var randomPointIndex = Random.Range(0, _configuration.asteroidSpawnPositions.Length);
                var randomPoint = spawnPositions[randomPointIndex];

                _flyingEntitiesFactory.Create(new Asteroid(), _configuration.asteroidPrefab, randomPoint,
                    new Quaternion());
                asteroidsSpawner.remainingDelayBeforeSpawn = _configuration.delayBetweenAsteroidsSpawn;
            }
        }
    }
}