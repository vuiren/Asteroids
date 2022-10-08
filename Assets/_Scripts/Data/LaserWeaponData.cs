using System;

namespace _Scripts.Data
{
    [Serializable]
    public class LaserWeaponData : WeaponData
    {
        public int laserShotsCount = 3;
        public float laserShotReloadTime = 1f;
    }
}