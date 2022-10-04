using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class AddVelocityToAsteroids : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public AddVelocityToAsteroids(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            foreach (var asteroid in _gameEntitiesBag.asteroids)
                if (Mathf.Approximately(asteroid.Velocity.magnitude, 0))
                    asteroid.Velocity = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        }
    }
}