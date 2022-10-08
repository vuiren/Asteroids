using System;
using UnityEngine;

namespace _Scripts.Physics
{
    public class CollisionDetector : MonoBehaviour
    {
        public Action<GameObject> OnCollision { get; set; }

        private void OnCollisionEnter2D(Collision2D col)
        {
            OnCollision?.Invoke(gameObject);
        }
    }
}