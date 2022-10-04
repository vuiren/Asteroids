using UnityEngine;

namespace _Scripts.Data
{
    [CreateAssetMenu(fileName = "New Configuration", menuName = "Add Configuration", order = 0)]
    public class Configuration : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public float MaxVelocity = 10f;
        public float DelayBetweenAsteroidsSpawn = 5f;
    }
}