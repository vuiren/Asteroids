using UnityEngine;

namespace _Scripts.Entities.FlyingEntities
{
    public class AsteroidShard : FlyingEntity
    {
        public AsteroidShard(string name = "Asteroid Shard") : base(name)
        {
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            markedForDestroying = true;
        }
    }
}