using UnityEngine;

namespace _Scripts.MonoLinks.Objects.FlyingEntities.Projectiles
{
    public class Bullet : Projectile
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            MarkedForDestroying = true;
        }
    }
}