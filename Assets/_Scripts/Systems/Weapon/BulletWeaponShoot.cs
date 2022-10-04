using _Scripts.Factories;
using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems.Weapon
{
    public class BulletWeaponShoot: IRunSystem
    {
        private readonly FlyingEntitiesFactory _flyingEntitiesFactory;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public BulletWeaponShoot(FlyingEntitiesFactory flyingEntitiesFactory, GameEntitiesBag gameEntitiesBag)
        {
            _flyingEntitiesFactory = flyingEntitiesFactory;
            _gameEntitiesBag = gameEntitiesBag;
        }
        
        public void Run()
        {
            if (!Input.GetMouseButton(0))
            {
                return;
            }
            
            foreach (var weapon in _gameEntitiesBag.bulletWeapons)
            {
                if(!weapon.Active) continue;

                if (!(weapon.RemainingDelayBetweenShots <= 0)) continue;
                
                _flyingEntitiesFactory.Create(weapon.Projectile, weapon.ProjectileSpawnPoint);
                weapon.RemainingDelayBetweenShots = weapon.DelayBetweenShots;
            }    
        }
    }
}