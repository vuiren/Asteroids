using System;
using UnityEngine;

namespace _Scripts.Data
{
    [Serializable]
    public class WeaponData
    {
        public Vector2 offsetFromPlayer;
        public GameObject projectilePrefab;
        public float projectileSpeed;
        public float delayBetweenShots;
    }
}