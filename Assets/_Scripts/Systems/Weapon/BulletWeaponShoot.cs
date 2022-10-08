using _Scripts.Data;
using _Scripts.Entities.FlyingEntities.Projectiles;
using _Scripts.Entities.Weapons;
using _Scripts.Extensions;
using _Scripts.Factories;
using _Scripts.MonoLinks;
using _Scripts.Services;
using UnityEngine;

namespace _Scripts.Systems.Weapon
{
    public class BulletWeaponShoot : ShootSystem<BulletWeapon>
    {
        public BulletWeaponShoot(Configuration configuration, FlyingEntitiesFactory flyingEntitiesFactory,
            GameEntitiesBag gameEntitiesBag, InputService inputService) : base(configuration, flyingEntitiesFactory,
            gameEntitiesBag, inputService)
        {
        }

        protected override bool InputCheck()
        {
            return InputService.FireButtonPressed;
        }

        protected override void Shoot(BulletWeapon weapon, Transform playerTransform)
        {
            var bullet = new Bullet
            {
                velocity = playerTransform.up * Configuration.bulletWeaponData.projectileSpeed
            };
            var spawnPosition = playerTransform.position +
                                playerTransform.TransformVector(weapon.projectileOffsetFromPlayer.Vector3());

            FlyingEntitiesFactory.Create(bullet, weapon.Projectile, spawnPosition,
                Quaternion.Euler(playerTransform.up));
            weapon.RemainingDelayBetweenShots = weapon.DelayBetweenShots;
        }
    }
}