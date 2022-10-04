using UnityEngine;

namespace _Scripts.MonoLinks.Objects
{
    public class AsteroidsSpawner: GameEntity
    {
        public bool active = true;
        public GameObject asteroidPrefab;
        public Transform[] possibleSpawnPoints;
        public float RemainingDelayBeforeAsteroidSpawn;
    }
}