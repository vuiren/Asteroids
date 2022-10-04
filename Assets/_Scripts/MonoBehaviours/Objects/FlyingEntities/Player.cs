using System;
using _Scripts.MonoLinks.Objects.Weapons;
using UnityEngine;

namespace _Scripts.MonoLinks
{
    public class Player : FlyingEntity
    {
        public float moveSpeed = 5f, rotationSpeed = 60f;
        public Weapon BulletWeapon, LaserWeapon;
        public bool bulletWeaponEnabled = true;
        public bool laserWeaponEnabled;

        private void OnCollisionEnter2D(Collision2D col)
        {
            MarkedForDestroying = true;
        }
    }
}