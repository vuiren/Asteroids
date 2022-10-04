using UnityEngine;

namespace _Scripts.MonoLinks
{
    public class Asteroid: FlyingEntity
    {
        public GameObject shardPrefab;
        public Transform[] asteroidShardSpawnPoints;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            MarkedForDestroying = true;
        }
    }
}