using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class ReduceTimeForAsteroidsSpawner: IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public ReduceTimeForAsteroidsSpawner(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }
        
        public void Run()
        {
            foreach (var asteroidsSpawner in _gameEntitiesBag.asteroidsSpawners)
            {
                asteroidsSpawner.RemainingDelayBeforeAsteroidSpawn -= Time.deltaTime;
            }
        }
    }
}