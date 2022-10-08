using _Scripts.Data;
using _Scripts.Entities.FlyingEntities;
using _Scripts.Extensions;
using _Scripts.Factories;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class SpawnAsteroidShardsOnDestroying : IRunSystem
    {
        private readonly Configuration _configuration;
        private readonly FlyingEntitiesFactory _flyingEntitiesFactory;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public SpawnAsteroidShardsOnDestroying(Configuration configuration, FlyingEntitiesFactory flyingEntitiesFactory,
            GameEntitiesBag gameEntitiesBag)
        {
            _configuration = configuration;
            _flyingEntitiesFactory = flyingEntitiesFactory;
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            if (_gameEntitiesBag.players.Length == 0) return;

            foreach (var asteroid in _gameEntitiesBag.asteroids)
            {
                if (!asteroid.markedForDestroying) continue;

                foreach (var spawnOffset in asteroid.AsteroidShardSpawnOffsets)
                {
                    var asteroidShard = new AsteroidShard
                    {
                        velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f))
                    };
                    _flyingEntitiesFactory.Create(asteroidShard, _configuration.asteroidShard,
                        asteroid.transform.position + spawnOffset.Vector3(),
                        new Quaternion());
                }
            }
        }
    }
}