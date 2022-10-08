using UnityEngine;

namespace _Scripts.Data
{
    [CreateAssetMenu(fileName = "New Configuration", menuName = "Add Configuration", order = 0)]
    public class Configuration : ScriptableObject
    {
        public GameObject playerPrefab, asteroidPrefab, asteroidShard, ufoPrefab;
        public UFOData ufoData;
        public PlayerData playerData;
        public WeaponData bulletWeaponData;
        public LaserWeaponData laserWeaponData;
        public Vector2[] asteroidSpawnPositions, ufoSpawnPositions;
        public float maxFlyingEntitiesVelocity = 10f;
        public float delayBetweenAsteroidsSpawn = 5f, delayBetweenUfosSpawn = 7f;
    }
}