using UnityEngine;

namespace _Scripts.MonoLinks
{
    public class GameEntity : MonoBehaviour
    {
        public bool MarkedForDestroying, Destroyed;
        public GameObject GameObject => gameObject;
        public Transform Transform => transform;
    }
}