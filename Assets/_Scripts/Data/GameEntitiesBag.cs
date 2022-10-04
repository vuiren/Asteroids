using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.MonoLinks.Objects;
using _Scripts.MonoLinks.Objects.FlyingEntities.Projectiles;
using _Scripts.MonoLinks.Objects.UI;
using _Scripts.MonoLinks.Objects.Weapons;

namespace _Scripts.MonoLinks
{
    [Serializable]
    public class GameEntitiesBag
    {
        public List<GameEntity> gameEntities;

        public Asteroid[] asteroids;
        public FlyingEntity[] flyingEntities;
        public Player[] players;
        public Bullet[] bullets;
        public Weapon[] weapons;
        public AsteroidsSpawner[] asteroidsSpawners;
        public Projectile[] projectiles;
        public UFO[] ufos;
        public UI[] uis;
        public LaserWeapon[] laserWeapons;
        public BulletWeapon[] bulletWeapons;
        public Score[] scores;
        public AsteroidShard[] asteroidShards;
        public GameOverScreen[] gameOverScreens;
        public RestartGame[] restartGames;
        public PlayerSpawnPoint[] playerSpawnPoints;

        public GameEntitiesBag(List<GameEntity> gameEntities)
        {
            this.gameEntities = gameEntities;
        }

        public void UpdateEntitiesList()
        {
            RemoveDestroyedEntities();
            asteroids = Filter<Asteroid>(gameEntities);
            players = Filter<Player>(gameEntities);
            weapons = Filter<Weapon>(gameEntities);
            bullets = Filter<Bullet>(gameEntities);
            flyingEntities = Filter<FlyingEntity>(gameEntities);
            asteroidsSpawners = Filter<AsteroidsSpawner>(gameEntities);
            projectiles = Filter<Projectile>(gameEntities);
            ufos = Filter<UFO>(gameEntities);
            uis = Filter<UI>(gameEntities);
            laserWeapons = Filter<LaserWeapon>(gameEntities);
            bulletWeapons = Filter<BulletWeapon>(gameEntities);
            scores = Filter<Score>(gameEntities);
            asteroidShards = Filter<AsteroidShard>(gameEntities);
            gameOverScreens = Filter<GameOverScreen>(gameEntities);
            restartGames = Filter<RestartGame>(gameEntities);
            playerSpawnPoints = Filter<PlayerSpawnPoint>(gameEntities);
        }

        private void RemoveDestroyedEntities()
        {
            gameEntities = gameEntities.Where(x => !x.Destroyed).ToList();
        }

        private T[] Filter<T>(IEnumerable<GameEntity> gameEntities) where T : GameEntity
        {
            return gameEntities
                .Where(x => x.GetComponent<T>())
                .Select(x => x.GetComponent<T>())
                .ToArray();
        }
    }
}