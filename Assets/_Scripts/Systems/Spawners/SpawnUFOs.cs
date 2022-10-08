using _Scripts.Data;
using _Scripts.Factories;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems.UFO
{
    public class SpawnUFOs : IRunSystem
    {
        private readonly Configuration _configuration;
        private readonly FlyingEntitiesFactory _flyingEntitiesFactory;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public SpawnUFOs(Configuration configuration, FlyingEntitiesFactory flyingEntitiesFactory,
            GameEntitiesBag gameEntitiesBag)
        {
            _configuration = configuration;
            _gameEntitiesBag = gameEntitiesBag;
            _flyingEntitiesFactory = flyingEntitiesFactory;
        }

        public void Run()
        {
            foreach (var ufosSpawner in _gameEntitiesBag.ufosSpawners)
            {
                var spawnPositions = _configuration.ufoSpawnPositions;
                if (spawnPositions.Length == 0) continue;
                if (ufosSpawner.remainingDelayBeforeSpawn > 0) continue;
                if (!ufosSpawner.active) continue;

                var randomPointIndex = Random.Range(0, spawnPositions.Length);
                var randomPoint = spawnPositions[randomPointIndex];

                var ufoInstance = new Entities.FlyingEntities.UFO
                {
                    moveSpeed = _configuration.ufoData.moveSpeed
                };

                _flyingEntitiesFactory.Create(ufoInstance, _configuration.ufoPrefab, randomPoint, new Quaternion());
                ufosSpawner.remainingDelayBeforeSpawn = _configuration.delayBetweenUfosSpawn;
            }
        }
    }
}