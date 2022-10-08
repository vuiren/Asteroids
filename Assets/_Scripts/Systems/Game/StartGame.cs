using _Scripts.Data;
using _Scripts.Entities.FlyingEntities;
using _Scripts.Factories;
using UnityEngine;

namespace _Scripts.Systems
{
    public class StartGame : IStartSystem
    {
        private readonly Configuration _configuration;
        private readonly FlyingEntitiesFactory _flyingEntitiesFactory;

        public StartGame(Configuration configuration, FlyingEntitiesFactory flyingEntitiesFactory)
        {
            _configuration = configuration;
            _flyingEntitiesFactory = flyingEntitiesFactory;
        }

        public void Start()
        {
            var player = new Player
            {
                moveSpeed = _configuration.playerData.moveSpeed,
                rotationSpeed = _configuration.playerData.rotationSpeed
            };
            _flyingEntitiesFactory.Create(player, _configuration.playerPrefab, Vector2.zero, new Quaternion());
        }
    }
}