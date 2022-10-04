using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems.Weapon.Laser
{
    public class ReloadLaserWeapon : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public ReloadLaserWeapon(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            foreach (var laserWeapon in _gameEntitiesBag.laserWeapons)
            {
                if (laserWeapon.remainingLaserShotsCount >= laserWeapon.laserShotsCount) continue;

                laserWeapon.remainingLaserShotReloadTime -= Time.deltaTime;
                if (!(laserWeapon.remainingLaserShotReloadTime <= 0)) continue;

                laserWeapon.remainingLaserShotsCount++;
                laserWeapon.remainingLaserShotReloadTime = laserWeapon.laserShotReloadTime;
            }
        }
    }
}