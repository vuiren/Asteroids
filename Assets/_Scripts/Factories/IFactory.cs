using UnityEngine;

namespace _Scripts.Factories
{
    public interface IFactory
    {
        void Create(GameObject prefab, Transform spawnPoint);
    }
}