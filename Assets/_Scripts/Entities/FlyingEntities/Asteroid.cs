using UnityEngine;

namespace _Scripts.Entities.FlyingEntities
{
    public class Asteroid : FlyingEntity
    {
        public readonly Vector2[] AsteroidShardSpawnOffsets = { new(0.1f, 0.1f), new(0.1f, -0.1f), new(-0.1f, 0.1f) };
        private Collider2D collider;
        public GameObject shardPrefab;

        public Asteroid(string name = "Asteroid") : base(name)
        {
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            markedForDestroying = true;
        }
    }
}