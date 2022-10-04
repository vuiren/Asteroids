using _Scripts.Factories;
using _Scripts.MonoLinks;
using _Scripts.Services;
using UnityEngine;

namespace _Scripts.Systems.Weapon
{
    public class BulletWeaponShoot : IRunSystem
    {
        private readonly FlyingEntitiesFactory _flyingEntitiesFactory;
        private readonly GameEntitiesBag _gameEntitiesBag;
        private readonly InputService _inputService;

        public BulletWeaponShoot(FlyingEntitiesFactory flyingEntitiesFactory, GameEntitiesBag gameEntitiesBag,
            InputService inputService)
        {
            _flyingEntitiesFactory = flyingEntitiesFactory;
            _gameEntitiesBag = gameEntitiesBag;
            _inputService = inputService;
        }

        public void Run()
        {
            if (!_inputService.FireButtonPressed) return;

            foreach (var weapon in _gameEntitiesBag.bulletWeapons)
            {
                if (!weapon.Active) continue;

                if (!(weapon.RemainingDelayBetweenShots <= 0)) continue;

                _flyingEntitiesFactory.Create(weapon.Projectile, weapon.ProjectileSpawnPoint);
                weapon.RemainingDelayBetweenShots = weapon.DelayBetweenShots;
            }
        }
    }
}