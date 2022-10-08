using System;
using UnityEngine;

namespace _Scripts.Entities
{
    [Serializable]
    public class GameEntity
    {
        public string name = "Game Entity";
        public bool markedForDestroying, destroyed;
        public GameObject gameObject;
        public Transform transform;

        public GameEntity(string name)
        {
            this.name = name;
        }
    }
}