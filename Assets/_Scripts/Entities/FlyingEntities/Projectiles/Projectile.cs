using System;

namespace _Scripts.Entities.FlyingEntities.Projectiles
{
    [Serializable]
    public abstract class Projectile : FlyingEntity
    {
        protected Projectile(string name = "Projectile") : base(name)
        {
        }
    }
}