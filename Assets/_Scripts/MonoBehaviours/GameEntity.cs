using UnityEngine;

namespace _Scripts.MonoLinks
{
    public class GameEntity : MonoBehaviour
    {
        public GameObject GameObject => gameObject;
        public Transform Transform => transform;
        public bool MarkedForDestroying, Destroyed;
    }
}