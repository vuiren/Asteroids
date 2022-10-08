using _Scripts.Entities.FlyingEntities;
using _Scripts.MonoLinks;
using _Scripts.Physics;
using UnityEngine;

namespace _Scripts.Factories
{
    public class FlyingEntitiesFactory : IFactory<FlyingEntity>
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public FlyingEntitiesFactory(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Create(FlyingEntity instance, GameObject prefab, Vector2 spawnPosition, Quaternion spawnRotation)
        {
            var gameObject = Object.Instantiate(prefab, spawnPosition, spawnRotation);
            instance.gameObject = gameObject;
            instance.transform = gameObject.transform;
            instance.velocity = gameObject.transform.TransformVector(instance.velocity);
            instance.collisionDetector = gameObject.GetComponent<CollisionDetector>();

            _gameEntitiesBag.gameEntities.Add(instance);
            _gameEntitiesBag.UpdateEntitiesList();
        }
    }
}