using _Scripts.Data;
using _Scripts.MonoLinks;

namespace _Scripts.Systems.Spawn
{
    public class SpawnAsteroidShards : IRunSystem
    {
        private Configuration _configuration;
        private GameEntitiesBag _gameEntitiesBag;

        public SpawnAsteroidShards(Configuration configuration, GameEntitiesBag gameEntitiesBag)
        {
            _configuration = configuration;
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
        }
    }
}