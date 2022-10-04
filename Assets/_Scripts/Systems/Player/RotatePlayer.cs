using _Scripts.MonoLinks;
using _Scripts.Services;
using UnityEngine;

namespace _Scripts.Systems
{
    public class RotatePlayer : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;
        private readonly InputService _inputService;

        public RotatePlayer(GameEntitiesBag gameEntitiesBag, InputService inputService)
        {
            _gameEntitiesBag = gameEntitiesBag;
            _inputService = inputService;
        }

        public void Run()
        {
            var horizontal = -_inputService.RotateValue.x;
            foreach (var player in _gameEntitiesBag.players)
                player.transform.Rotate(0, 0, horizontal * player.rotationSpeed * Time.deltaTime);
        }
    }
}