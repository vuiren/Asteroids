using _Scripts.Factories;
using _Scripts.MonoLinks;

namespace _Scripts.Systems
{
    public class SpawnAsteroidShardsOnDestroying : IRunSystem
    {
        private readonly FlyingEntitiesFactory _flyingEntitiesFactory;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public SpawnAsteroidShardsOnDestroying(FlyingEntitiesFactory flyingEntitiesFactory, GameEntitiesBag gameEntitiesBag)
        {
            _flyingEntitiesFactory = flyingEntitiesFactory;
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            if(_gameEntitiesBag.players.Length == 0) return;
            
            foreach (var asteroid in _gameEntitiesBag.asteroids)
            {
                if (!asteroid.MarkedForDestroying) continue;
                
                foreach (var spawnPoint in asteroid.asteroidShardSpawnPoints)
                {
                    _flyingEntitiesFactory.Create(asteroid.shardPrefab, spawnPoint);
                }
            }
        }
    }
}