using _Scripts.Data;
using _Scripts.Entities.Weapons;
using _Scripts.Extensions;
using _Scripts.Factories;
using _Scripts.MonoLinks;
using _Scripts.Services;
using UnityEngine;

namespace _Scripts.Systems.Weapon.Laser
{
    public class LaserWeaponShoot : ShootSystem<LaserWeapon>
    {
        public LaserWeaponShoot(Configuration configuration, FlyingEntitiesFactory flyingEntitiesFactory,
            GameEntitiesBag gameEntitiesBag, InputService inputService) : base(configuration, flyingEntitiesFactory,
            gameEntitiesBag, inputService)
        {
        }

        protected override bool InputCheck()
        {
            return InputService.FireLaserButtonPressed;
        }

        protected override void Shoot(LaserWeapon weapon, Transform playerTransform)
        {
            if (weapon.remainingLaserShotsCount <= 0) return;
            var laser = new Entities.FlyingEntities.Projectiles.Laser
            {
                velocity = Vector2.up * Configuration.laserWeaponData.projectileSpeed
            };

            var spawnPosition = playerTransform.position +
                                playerTransform.TransformVector(weapon.projectileOffsetFromPlayer.Vector3());

            FlyingEntitiesFactory.Create(laser, weapon.Projectile, spawnPosition,
                playerTransform.rotation);

            weapon.RemainingDelayBetweenShots = weapon.DelayBetweenShots;
            weapon.remainingLaserShotsCount -= 1;
        }
    }
}