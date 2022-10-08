using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems.Weapon
{
    public class DestroyProjectilesOffScreen : IRunSystem
    {
        private readonly Camera _camera;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public DestroyProjectilesOffScreen(Camera camera, GameEntitiesBag gameEntitiesBag)
        {
            _camera = camera;
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            var screenWidth = Screen.width;
            var screenHeight = Screen.height;

            foreach (var projectile in _gameEntitiesBag.projectiles)
            {
                var position = projectile.transform.position;
                var screenPosition = _camera.WorldToScreenPoint(position);
                var startScreenPos = _camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
                var endScreenPos = _camera.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 0));

                if (position.x > endScreenPos.x || position.x < startScreenPos.x) projectile.markedForDestroying = true;

                if (position.y > endScreenPos.y || position.y < startScreenPos.y) projectile.markedForDestroying = true;
            }
        }
    }
}