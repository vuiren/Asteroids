using _Scripts.Extensions;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class PlayerLookAtCursor : IRunSystem
    {
        private readonly Camera _camera;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public PlayerLookAtCursor(Camera camera, GameEntitiesBag gameEntitiesBag)
        {
            _camera = camera;
            _gameEntitiesBag = gameEntitiesBag;
        }


        public void Run()
        {
            var cursorPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            foreach (var player in _gameEntitiesBag.players)
            {
                var dif = cursorPosition.Vector2() - player.transform.position.Vector2();
                player.transform.up = dif.normalized;
            }
        }
    }
}