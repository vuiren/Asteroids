using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Factories
{
    public class FlyingEntitiesFactory : IFactory
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public FlyingEntitiesFactory(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Create(GameObject prefab, Transform spawnPoint)
        {
            var instance = Object.Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            var flyingEntity = instance.GetComponent<FlyingEntity>();
            flyingEntity.Velocity = flyingEntity.transform.TransformVector(flyingEntity.Velocity);
            var gameEntities = instance.GetComponentsInChildren<GameEntity>();
            foreach (var gameEntity in gameEntities) _gameEntitiesBag.gameEntities.Add(gameEntity);
            _gameEntitiesBag.UpdateEntitiesList();
        }
    }
}