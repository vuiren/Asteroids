using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems
{
    public class SwitchWeapons: IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public SwitchWeapons(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }
        
        public void Run()
        {
            if(!Input.GetMouseButtonDown(1)) return;
            
            foreach (var player in _gameEntitiesBag.players)
            {
                player.bulletWeaponEnabled = !player.bulletWeaponEnabled;
                player.laserWeaponEnabled = !player.laserWeaponEnabled;
                player.BulletWeapon.Active = player.bulletWeaponEnabled;
                player.LaserWeapon.Active = player.laserWeaponEnabled;
            }
        }
    }
}