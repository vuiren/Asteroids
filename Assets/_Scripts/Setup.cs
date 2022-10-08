using System.Collections.Generic;
using _Scripts.Data;
using _Scripts.Entities;
using _Scripts.Entities.Spawners;
using _Scripts.Entities.UI;
using _Scripts.Entities.Weapons;
using _Scripts.Factories;
using _Scripts.MonoLinks;
using _Scripts.MonoLinks.Objects.UI;
using _Scripts.Services;
using _Scripts.Systems;
using _Scripts.Systems.Physics;
using _Scripts.Systems.Score;
using _Scripts.Systems.Spawn;
using _Scripts.Systems.UFO;
using _Scripts.Systems.UI;
using _Scripts.Systems.Weapon;
using _Scripts.Systems.Weapon.Laser;
using UnityEngine;
using UnityEngine.InputSystem;
using RestartGame = _Scripts.Entities.Game.RestartGame;

namespace _Scripts
{
    public static class Setup
    {
        public static void Init(Configuration configuration, PlayerInput playerInput, UISceneData uiSceneData,
            Camera camera, ref GameEntitiesBag gameEntitiesBag, ref IStartSystem[] startSystems,
            ref IRunSystem[] runSystems)
        {
            var startSystemsList = new List<IStartSystem>();
            var runSystemsList = new List<IRunSystem>();

            var inputService = new InputService(playerInput);

            gameEntitiesBag = new GameEntitiesBag(new List<GameEntity>
            {
                new AsteroidsSpawner(),
                new AsteroidsSpawner(),
                new UFOsSpawner(),
                new Score(),
                new RestartGame(),
                new UI
                {
                    rotationText = uiSceneData.rotationText,
                    currentSpeedText = uiSceneData.currentSpeedText,
                    laserReloadText = uiSceneData.laserReloadText,
                    coordinatesText = uiSceneData.coordinatesText,
                    laserShotsCountText = uiSceneData.laserShotsCountText
                },
                new GameOverScreen
                {
                    gameOverScreenUI = uiSceneData.gameOverScreenUI,
                    restartButton = uiSceneData.restartButton,
                    scoreText = uiSceneData.scoreText
                },
                new BulletWeapon
                {
                    Projectile = configuration.bulletWeaponData.projectilePrefab,
                    DelayBetweenShots = configuration.bulletWeaponData.delayBetweenShots,
                    projectileOffsetFromPlayer = configuration.bulletWeaponData.offsetFromPlayer,
                    Active = true
                },
                new LaserWeapon
                {
                    Projectile = configuration.laserWeaponData.projectilePrefab,
                    DelayBetweenShots = configuration.laserWeaponData.delayBetweenShots,
                    laserShotsCount = configuration.laserWeaponData.laserShotsCount,
                    laserShotReloadTime = configuration.laserWeaponData.laserShotReloadTime,
                    projectileOffsetFromPlayer = configuration.laserWeaponData.offsetFromPlayer,
                    Active = true
                }
            });

            gameEntitiesBag.UpdateEntitiesList();

            var flyingEntitiesFactory = new FlyingEntitiesFactory(gameEntitiesBag);

            startSystemsList.Add(new RestartGameButtonHandler(gameEntitiesBag));
            startSystemsList.Add(new StartGame(configuration, flyingEntitiesFactory));

            runSystemsList.Add(new MarkCollidedForDeath(gameEntitiesBag));

            AddSpawnSystems(runSystemsList, configuration, flyingEntitiesFactory, gameEntitiesBag);
            AddMoveSystems(runSystemsList, configuration, inputService, gameEntitiesBag);
            AddWeaponSystems(runSystemsList, configuration, flyingEntitiesFactory, inputService, gameEntitiesBag);
            AddScreenHandlerSystems(runSystemsList, camera, gameEntitiesBag);
            AddDestroyHandlerSystems(runSystemsList, configuration, flyingEntitiesFactory, gameEntitiesBag);

            runSystemsList.Add(new SyncUI(gameEntitiesBag, camera));
            runSystemsList.Add(new Systems.RestartGame(configuration, gameEntitiesBag, flyingEntitiesFactory));

            startSystems = startSystemsList.ToArray();
            runSystems = runSystemsList.ToArray();
        }

        private static void AddWeaponSystems(ICollection<IRunSystem> runSystemsList, Configuration configuration,
            FlyingEntitiesFactory flyingEntitiesFactory, InputService inputService, GameEntitiesBag gameEntitiesBag)
        {
            runSystemsList.Add(new BulletWeaponShoot(configuration, flyingEntitiesFactory, gameEntitiesBag,
                inputService));
            runSystemsList.Add(
                new LaserWeaponShoot(configuration, flyingEntitiesFactory, gameEntitiesBag, inputService));
            runSystemsList.Add(new ReloadLaserWeapon(gameEntitiesBag));
            runSystemsList.Add(new Reload(gameEntitiesBag));
        }

        private static void AddMoveSystems(ICollection<IRunSystem> runSystemsList, Configuration configuration,
            InputService inputService, GameEntitiesBag gameEntitiesBag)
        {
            runSystemsList.Add(new UFOFollowPlayer(gameEntitiesBag));
            runSystemsList.Add(new AddVelocityToAsteroids(gameEntitiesBag));
            runSystemsList.Add(new AddVelocityToPlayer(gameEntitiesBag, inputService));
            runSystemsList.Add(new DecreasePlayerVelocity(gameEntitiesBag));
            runSystemsList.Add(new ClampFlyingEntitiesVelocity(configuration, gameEntitiesBag));
            runSystemsList.Add(new MoveFlyingEntities(gameEntitiesBag));
            runSystemsList.Add(new RotatePlayer(gameEntitiesBag, inputService));
        }

        private static void AddSpawnSystems(ICollection<IRunSystem> runSystemsList, Configuration configuration,
            FlyingEntitiesFactory flyingEntitiesFactory, GameEntitiesBag gameEntitiesBag)
        {
            runSystemsList.Add(new ReduceTimeForSpawners(gameEntitiesBag));
            runSystemsList.Add(new SpawnAsteroids(configuration, flyingEntitiesFactory, gameEntitiesBag));
            runSystemsList.Add(new SpawnUFOs(configuration, flyingEntitiesFactory, gameEntitiesBag));
        }

        private static void AddDestroyHandlerSystems(ICollection<IRunSystem> runSystemsList,
            Configuration configuration,
            FlyingEntitiesFactory flyingEntitiesFactory, GameEntitiesBag gameEntitiesBag)
        {
            runSystemsList.Add(new CountScoreOnEntitesDeaths(gameEntitiesBag));

            runSystemsList.Add(new ShowGameOverScreenOnPlayerDeath(gameEntitiesBag));
            runSystemsList.Add(
                new SpawnAsteroidShardsOnDestroying(configuration, flyingEntitiesFactory, gameEntitiesBag));
            runSystemsList.Add(new DestroyGameEntities(gameEntitiesBag));
        }

        private static void AddScreenHandlerSystems(ICollection<IRunSystem> runSystemsList, Camera camera,
            GameEntitiesBag gameEntitiesBag)
        {
            runSystemsList.Add(new DestroyProjectilesOffScreen(camera, gameEntitiesBag));
            runSystemsList.Add(new KeepFlyingEntitiesOnScreen(camera, gameEntitiesBag));
        }
    }
}