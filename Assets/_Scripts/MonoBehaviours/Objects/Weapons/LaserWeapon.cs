namespace _Scripts.MonoLinks.Objects.Weapons
{
    public class LaserWeapon : Weapon
    {
        public int laserShotsCount = 3;
        public int remainingLaserShotsCount;
        public float laserShotReloadTime = 1f, remainingLaserShotReloadTime;
    }
}