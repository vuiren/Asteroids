using _Scripts.Extensions;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class MoveFlyingEntities : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public MoveFlyingEntities(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            foreach (var flyingEntity in _gameEntitiesBag.flyingEntities)
            {
                var position = flyingEntity.transform.position.Vector2();
                var velocity = flyingEntity.Velocity;
                flyingEntity.transform.position = position + velocity * Time.deltaTime;
            }
        }
    }
}