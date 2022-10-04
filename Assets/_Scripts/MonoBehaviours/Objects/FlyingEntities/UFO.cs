using System;
using UnityEngine;

namespace _Scripts.MonoLinks
{
    public class UFO: FlyingEntity
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            MarkedForDestroying = true;
        }
    }
}