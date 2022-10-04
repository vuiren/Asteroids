using UnityEngine;

namespace _Scripts.MonoLinks
{
    public class UFO : FlyingEntity
    {
        public float moveSpeed;

        private void OnCollisionEnter2D(Collision2D col)
        {
            MarkedForDestroying = true;
        }
    }
}