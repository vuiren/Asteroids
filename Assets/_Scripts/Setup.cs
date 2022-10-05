using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Data;
using _Scripts.Factories;
using _Scripts.MonoLinks;
using _Scripts.MonoLinks.Objects.UI;
using _Scripts.Services;
using _Scripts.Systems;
using _Scripts.Systems.Score;
using _Scripts.Systems.UFO;
using _Scripts.Systems.UI;
using _Scripts.Systems.Weapon;
using _Scripts.Systems.Weapon.Laser;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public static class Setup
    {
        public static void Init(Configuration configuration, PlayerInput playerInput,
            Camera camera, ref GameEntitiesBag gameEntitiesBag, ref IStartSystem[] startSystems,
            ref IRunSystem[] runSystems)
        {
            var startSystemsList = new List<IStartSystem>();
            var runSystemsList = new List<IRunSystem>();

            var gameEntities = GameObject.FindObjectsOfType<GameEntity>().ToList();
            var inputService = new InputService(playerInput);

            gameEntitiesBag = new GameEntitiesBag(gameEntities);
            gameEntitiesBag.UpdateEntitiesList();

            var flyingEntitiesFactory = new FlyingEntitiesFactory(gameEntitiesBag);

            startSystemsList.Add(new RestartGameButtonHandler(gameEntitiesBag));

            runSystemsList.Add(new ReduceTimeForAsteroidsSpawner(gameEntitiesBag));
            runSystemsList.Add(new SpawnAsteroids(configuration, flyingEntitiesFactory, gameEntitiesBag));

            runSystemsList.Add(new UFOFollowPlayer(gameEntitiesBag));

            runSystemsList.Add(new AddVelocityToAsteroids(gameEntitiesBag));
            runSystemsList.Add(new AddVelocityToPlayer(gameEntitiesBag, inputService));
            runSystemsList.Add(new DecreasePlayerVelocity(gameEntitiesBag));
            runSystemsList.Add(new ClampFlyingEntitiesVelocity(configuration, gameEntitiesBag));
            runSystemsList.Add(new MoveFlyingEntities(gameEntitiesBag));

            runSystemsList.Add(new RotatePlayer(gameEntitiesBag, inputService));

            runSystemsList.Add(new SwitchWeapons(gameEntitiesBag));
            runSystemsList.Add(new BulletWeaponShoot(flyingEntitiesFactory, gameEntitiesBag, inputService));
            runSystemsList.Add(new LaserShoot(gameEntitiesBag, flyingEntitiesFactory, inputService));
            runSystemsList.Add(new ReloadLaserWeapon(gameEntitiesBag));
            runSystemsList.Add(new Reload(gameEntitiesBag));

            runSystemsList.Add(new DestroyProjectilesOffScreen(camera, gameEntitiesBag));
            runSystemsList.Add(new KeepFlyingEntitiesOnScreen(camera, gameEntitiesBag));

            runSystemsList.Add(new CountScore(gameEntitiesBag));
            runSystemsList.Add(new ShowGameOverScreen(gameEntitiesBag));

            runSystemsList.Add(new DestroyWeaponsOnPlayerDeath(gameEntitiesBag));
            runSystemsList.Add(new SpawnAsteroidShardsOnDestroying(flyingEntitiesFactory, gameEntitiesBag));
            runSystemsList.Add(new DestroyGameEntities(gameEntitiesBag));

            runSystemsList.Add(new SyncUI(gameEntitiesBag, camera));
            runSystemsList.Add(new RestartGame(configuration, gameEntitiesBag, flyingEntitiesFactory));

            startSystems = startSystemsList.ToArray();
            runSystems = runSystemsList.ToArray();
        }
    }
}