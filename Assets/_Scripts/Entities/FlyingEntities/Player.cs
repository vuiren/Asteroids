using System;

namespace _Scripts.Entities.FlyingEntities
{
    [Serializable]
    public class Player : FlyingEntity
    {
        public float moveSpeed = 5f, rotationSpeed = 60f;

        public Player(string name = "Player") : base(name)
        {
        }
    }
}