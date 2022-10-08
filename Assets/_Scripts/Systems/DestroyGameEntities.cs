using System.Linq;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class DestroyGameEntities : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public DestroyGameEntities(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            var listChanged = false;
            foreach (var gameEntity in
                     _gameEntitiesBag.gameEntities.Where(gameEntity => gameEntity.markedForDestroying))
            {
                Object.Destroy(gameEntity.gameObject);
                gameEntity.destroyed = true;
                listChanged = true;
            }

            if (listChanged) _gameEntitiesBag.UpdateEntitiesList();
        }
    }
}