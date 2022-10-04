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

namespace _Scripts
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private Configuration configuration;
        [SerializeField] private InputService inputService;
        [SerializeField] private GameEntitiesBag gameEntitiesBag;
        private readonly List<IRunSystem> _runSystems = new();

        private readonly List<IStartSystem> _startSystems = new();

        // Start is called before the first frame update
        private void Start()
        {
            var camera = Camera.main;
            var gameEntities = FindObjectsOfType<GameEntity>().ToList();

            gameEntitiesBag = new GameEntitiesBag(gameEntities);
            gameEntitiesBag.UpdateEntitiesList();

            var flyingEntitiesFactory = new FlyingEntitiesFactory(gameEntitiesBag);

            _startSystems.Add(new RestartGameButtonHandler(gameEntitiesBag));

            _runSystems.Add(new ReduceTimeForAsteroidsSpawner(gameEntitiesBag));
            _runSystems.Add(new SpawnAsteroids(configuration, flyingEntitiesFactory, gameEntitiesBag));

            _runSystems.Add(new UFOFollowPlayer(gameEntitiesBag));

            _runSystems.Add(new AddVelocityToAsteroids(gameEntitiesBag));
            _runSystems.Add(new AddVelocityToPlayer(gameEntitiesBag, inputService));
            _runSystems.Add(new DecreasePlayerVelocity(gameEntitiesBag));
            _runSystems.Add(new ClampFlyingEntitiesVelocity(configuration, gameEntitiesBag));
            _runSystems.Add(new MoveFlyingEntities(gameEntitiesBag));

            _runSystems.Add(new RotatePlayer(gameEntitiesBag, inputService));

            _runSystems.Add(new SwitchWeapons(gameEntitiesBag));
            _runSystems.Add(new BulletWeaponShoot(flyingEntitiesFactory, gameEntitiesBag, inputService));
            _runSystems.Add(new LaserShoot(gameEntitiesBag, flyingEntitiesFactory, inputService));
            _runSystems.Add(new ReloadLaserWeapon(gameEntitiesBag));
            _runSystems.Add(new Reload(gameEntitiesBag));

            _runSystems.Add(new DestroyProjectilesOffScreen(camera, gameEntitiesBag));
            _runSystems.Add(new KeepFlyingEntitiesOnScreen(camera, gameEntitiesBag));

            _runSystems.Add(new CountScore(gameEntitiesBag));
            _runSystems.Add(new ShowGameOverScreen(gameEntitiesBag));

            _runSystems.Add(new DestroyWeaponsOnPlayerDeath(gameEntitiesBag));
            _runSystems.Add(new SpawnAsteroidShardsOnDestroying(flyingEntitiesFactory, gameEntitiesBag));
            _runSystems.Add(new DestroyGameEntities(gameEntitiesBag));

            _runSystems.Add(new SyncUI(gameEntitiesBag, camera));
            _runSystems.Add(new RestartGame(configuration, gameEntitiesBag, flyingEntitiesFactory));


            foreach (var startSystem in _startSystems) startSystem.Start();
        }

        // Update is called once per frame
        private void Update()
        {
            foreach (var runSystem in _runSystems) runSystem.Run();
        }
    }
}