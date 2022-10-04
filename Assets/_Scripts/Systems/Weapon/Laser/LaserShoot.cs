using _Scripts.Factories;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems.Weapon.Laser
{
    public class LaserShoot: IRunSystem
    {
        private readonly FlyingEntitiesFactory _flyingEntitiesFactory;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public LaserShoot(GameEntitiesBag gameEntitiesBag, FlyingEntitiesFactory flyingEntitiesFactory)
        {
            _flyingEntitiesFactory = flyingEntitiesFactory;
            _gameEntitiesBag = gameEntitiesBag;
        }
        
        public void Run()
        {
            if(!Input.GetMouseButton(0)) return;

            foreach (var laserWeapon in _gameEntitiesBag.laserWeapons)
            {
                if(laserWeapon.remainingLaserShotsCount <= 0) continue;
                if(!laserWeapon.Active) continue;
                if (!(laserWeapon.RemainingDelayBetweenShots <= 0)) continue;
                
                _flyingEntitiesFactory.Create(laserWeapon.Projectile, laserWeapon.ProjectileSpawnPoint);
                laserWeapon.RemainingDelayBetweenShots = laserWeapon.DelayBetweenShots;
                laserWeapon.remainingLaserShotsCount -= 1;
            }
        }
    }
}