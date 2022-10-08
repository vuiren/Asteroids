using _Scripts.Entities;
using UnityEngine;

namespace _Scripts.Factories
{
    public interface IFactory<in T> where T : GameEntity
    {
        void Create(T instance, GameObject prefab, Vector2 spawnPosition, Quaternion spawnRotation);
    }
}