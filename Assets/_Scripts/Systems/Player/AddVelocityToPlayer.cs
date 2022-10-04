using _Scripts.Data;
using _Scripts.Extensions;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class AddVelocityToPlayer : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public AddVelocityToPlayer(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            if (!Input.GetKey(KeyCode.Space)) return;

            foreach (var player in _gameEntitiesBag.players)
            {
                player.Velocity += player.transform.up.Vector2() * (Time.deltaTime * player.moveSpeed);
            }
        }
    }
}