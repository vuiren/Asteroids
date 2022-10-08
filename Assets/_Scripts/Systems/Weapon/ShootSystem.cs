using System.Linq;
using _Scripts.Data;
using _Scripts.Factories;
using _Scripts.MonoLinks;
using _Scripts.Services;
using UnityEngine;

namespace _Scripts.Systems.Weapon
{
    public abstract class ShootSystem<T> : IRunSystem where T : Entities.Weapons.Weapon
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        protected readonly Configuration Configuration;
        protected readonly FlyingEntitiesFactory FlyingEntitiesFactory;
        protected readonly InputService InputService;

        protected ShootSystem(Configuration configuration, FlyingEntitiesFactory flyingEntitiesFactory,
            GameEntitiesBag gameEntitiesBag,
            InputService inputService)
        {
            Configuration = configuration;
            FlyingEntitiesFactory = flyingEntitiesFactory;
            _gameEntitiesBag = gameEntitiesBag;
            InputService = inputService;
        }

        public void Run()
        {
            if (!InputCheck()) return;
            if (_gameEntitiesBag.players.Length == 0) return;
            var player = _gameEntitiesBag.players[0];
            var playerTransform = player.transform;

            foreach (var weapon in _gameEntitiesBag.weapons.OfType<T>())
            {
                if (!weapon.Active) continue;

                if (!(weapon.RemainingDelayBetweenShots <= 0)) continue;

                Shoot(weapon, playerTransform);
            }
        }

        protected abstract bool InputCheck();

        protected abstract void Shoot(T weapon, Transform playerTransform);
    }
}