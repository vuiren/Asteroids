using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems.Weapon
{
    public class Reload : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public Reload(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            foreach (var weapon in _gameEntitiesBag.weapons) weapon.RemainingDelayBetweenShots -= Time.deltaTime;
        }
    }
}