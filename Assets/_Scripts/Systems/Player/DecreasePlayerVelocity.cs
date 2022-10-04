﻿using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class DecreasePlayerVelocity : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public DecreasePlayerVelocity(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            foreach (var player in _gameEntitiesBag.players)
            {
                var magnitude = player.Velocity.magnitude;
                magnitude -= Time.deltaTime;
                player.Velocity = player.Velocity.normalized * magnitude;
            }
        }
    }
}