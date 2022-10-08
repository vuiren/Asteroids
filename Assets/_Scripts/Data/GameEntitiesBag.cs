using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Entities;
using _Scripts.Entities.FlyingEntities;
using _Scripts.Entities.FlyingEntities.Projectiles;
using _Scripts.Entities.Game;
using _Scripts.Entities.Spawners;
using _Scripts.Entities.UI;
using _Scripts.Entities.Weapons;

namespace _Scripts.MonoLinks
{
    [Serializable]
    public class GameEntitiesBag
    {
        public List<GameEntity> gameEntities = new();
        public Player[] players;
        public Laser[] Lasers;
        public UFO[] ufos;
        public UI[] uis;
        public LaserWeapon[] laserWeapons;
        public GameOverScreen[] gameOverScreens;

        public Asteroid[] asteroids;
        public AsteroidShard[] asteroidShards;
        public AsteroidsSpawner[] asteroidsSpawners;
        public Bullet[] bullets;
        public BulletWeapon[] bulletWeapons;
        public FlyingEntity[] flyingEntities;
        public Projectile[] projectiles;
        public RestartGame[] restartGames;
        public Score[] scores;
        public Spawner[] spawners;
        public UFOsSpawner[] ufosSpawners;
        public Weapon[] weapons;

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
            spawners = Filter<Spawner>(gameEntities);
            ufosSpawners = Filter<UFOsSpawner>(gameEntities);
            Lasers = Filter<Laser>(gameEntities);
        }

        private void RemoveDestroyedEntities()
        {
            gameEntities = gameEntities.Where(x => !x.destroyed).ToList();
        }

        private T[] Filter<T>(IEnumerable<GameEntity> gameEntities) where T : GameEntity
        {
            return gameEntities
                .OfType<T>()
                .ToArray();
        }
    }
}