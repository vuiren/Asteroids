using _Scripts.Data;
using _Scripts.Factories;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class SpawnAsteroids: IRunSystem
    {
        private readonly Configuration _configuration;
        private readonly GameEntitiesBag _gameEntitiesBag;
        private readonly FlyingEntitiesFactory _flyingEntitiesFactory;

        public SpawnAsteroids(Configuration configuration, FlyingEntitiesFactory  flyingEntitiesFactory, GameEntitiesBag gameEntitiesBag)
        {
            _configuration = configuration;
            _gameEntitiesBag = gameEntitiesBag;
            _flyingEntitiesFactory = flyingEntitiesFactory;
        }
        
        public void Run()
        {
            foreach (var asteroidsSpawner in _gameEntitiesBag.asteroidsSpawners)
            {
                if(asteroidsSpawner.possibleSpawnPoints.Length == 0) continue;
                if(asteroidsSpawner.RemainingDelayBeforeAsteroidSpawn > 0) continue;
                if(!asteroidsSpawner.active) continue;
                
                
                var randomPointIndex = Random.Range(0, asteroidsSpawner.possibleSpawnPoints.Length);
                var randomPoint = asteroidsSpawner.possibleSpawnPoints[randomPointIndex];
                
                _flyingEntitiesFactory.Create(asteroidsSpawner.asteroidPrefab, randomPoint);
                asteroidsSpawner.RemainingDelayBeforeAsteroidSpawn = _configuration.DelayBetweenAsteroidsSpawn;
            }
        }
    }
}