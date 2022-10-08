using System;
using UnityEngine;

namespace _Scripts.Entities.Weapons
{
    [Serializable]
    public abstract class Weapon : GameEntity
    {
        public bool Active;
        public float DelayBetweenShots;
        public float RemainingDelayBetweenShots;
        public Vector2 projectileOffsetFromPlayer;
        public GameObject Projectile;

        protected Weapon(string name = "Weapon") : base(name)
        {
        }
    }
}