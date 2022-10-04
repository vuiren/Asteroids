using UnityEngine;

namespace _Scripts.MonoLinks.Objects.Weapons
{
    public abstract class Weapon : GameEntity
    {
        public bool Active;
        public float DelayBetweenShots;
        public float RemainingDelayBetweenShots;
        public Transform ProjectileSpawnPoint;
        public GameObject Projectile;
    }
}