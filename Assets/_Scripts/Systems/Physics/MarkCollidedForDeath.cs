using _Scripts.Entities;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems.Physics
{
    public class MarkCollidedForDeath : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public MarkCollidedForDeath(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            foreach (var flyingEntity in _gameEntitiesBag.flyingEntities)
            {
                if (flyingEntity.collisionDetectorSubscribed) continue;

                if (flyingEntity.collisionDetector == null)
                {
                    Debug.LogWarning("No collision detector on flying entity");
                    flyingEntity.collisionDetectorSubscribed = true;
                    continue;
                }

                flyingEntity.collisionDetector.OnCollision += _ => MarkForDeath(flyingEntity);
                flyingEntity.collisionDetectorSubscribed = true;
            }
        }

        private void MarkForDeath(GameEntity flyingEntity)
        {
            flyingEntity.markedForDestroying = true;
        }
    }
}