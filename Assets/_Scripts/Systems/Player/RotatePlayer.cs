using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class RotatePlayer: IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public RotatePlayer(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }
        
        public void Run()
        {
            var horizontal = -Input.GetAxisRaw("Horizontal");
            foreach (var player in _gameEntitiesBag.players)
            {
                player.transform.Rotate(0,0,horizontal * player.rotationSpeed * Time.deltaTime);
            }
        }
    }
}