using System;

namespace _Scripts.Entities.FlyingEntities
{
    [Serializable]
    public class UFO : FlyingEntity
    {
        public float moveSpeed = 4f;

        public UFO(string name = "UFO") : base(name)
        {
        }
    }
}