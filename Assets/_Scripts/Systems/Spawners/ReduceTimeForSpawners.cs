using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems.Spawn
{
    public class ReduceTimeForSpawners : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public ReduceTimeForSpawners(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            foreach (var spawner in _gameEntitiesBag.spawners)
                spawner.remainingDelayBeforeSpawn -= Time.deltaTime;
        }
    }
}