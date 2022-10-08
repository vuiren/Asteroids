using System;
using _Scripts.Physics;
using UnityEngine;

namespace _Scripts.Entities.FlyingEntities
{
    [Serializable]
    public abstract class FlyingEntity : GameEntity
    {
        public Vector2 velocity;
        public CollisionDetector collisionDetector;
        public bool collisionDetectorSubscribed;

        protected FlyingEntity(string name = "Flying Entity") : base(name)
        {
        }
    }
}