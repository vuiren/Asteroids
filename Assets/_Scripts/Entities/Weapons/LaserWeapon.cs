using System;

namespace _Scripts.Entities.Weapons
{
    [Serializable]
    public class LaserWeapon : Weapon
    {
        public int laserShotsCount = 3;
        public int remainingLaserShotsCount;
        public float laserShotReloadTime = 1f, remainingLaserShotReloadTime;

        public LaserWeapon(string name = "Laser Weapon") : base(name)
        {
        }
    }
}