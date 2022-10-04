using _Scripts.Extensions;
using _Scripts.MonoLinks;
using _Scripts.Services;
using UnityEngine;

namespace _Scripts.Systems
{
    public class AddVelocityToPlayer : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;
        private readonly InputService _inputService;
        
        public AddVelocityToPlayer(GameEntitiesBag gameEntitiesBag, InputService inputService)
        {
            _gameEntitiesBag = gameEntitiesBag;
            _inputService = inputService;
        }

        public void Run()
        {
            if (!_inputService.FlyButtonPressed) return;

            foreach (var player in _gameEntitiesBag.players)
            {
                player.Velocity += player.transform.up.Vector2() * (Time.deltaTime * player.moveSpeed);
            }
        }
    }
}