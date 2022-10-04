using System.Collections.Generic;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class KeepFlyingEntitiesOnScreen: IRunSystem
    {
        private readonly Camera _camera;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public KeepFlyingEntitiesOnScreen(Camera camera, GameEntitiesBag gameEntitiesBag)
        {
            _camera = camera;
            _gameEntitiesBag = gameEntitiesBag;
        }
        
        public void Run()
        {
            var screenWidth = Screen.width;
            var screenHeight = Screen.height;
            foreach (var entity in _gameEntitiesBag.flyingEntities)
            {
                var position = entity.transform.position;
                var screenPosition = _camera.WorldToScreenPoint(position);
                var startScreenPos = _camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
                var endScreenPos = _camera.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 0));
            
                if (screenPosition.x < 0)
                {
                    entity.transform.position = new Vector3(endScreenPos.x, position.y, 0);
                }
            
                if (screenPosition.x > screenWidth)
                {
                    entity.transform.position = new Vector3(startScreenPos.x, position.y, 0);
                }

                if (screenPosition.y < 0)
                {
                    entity.transform.position = new Vector3(position.x, endScreenPos.y, 0);
                }

                if (screenPosition.y > screenHeight)
                {
                    entity.transform.position = new Vector3(position.x, startScreenPos.y, 0);
                }
            }
        }
    }
}