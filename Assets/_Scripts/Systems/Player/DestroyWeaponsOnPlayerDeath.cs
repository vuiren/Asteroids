using _Scripts.MonoLinks;

namespace _Scripts.Systems
{
    public class DestroyWeaponsOnPlayerDeath : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public DestroyWeaponsOnPlayerDeath(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }


        public void Run()
        {
            foreach (var player in _gameEntitiesBag.players)
            {
                if (!player.markedForDestroying) continue;
                foreach (var weapon in _gameEntitiesBag.weapons) weapon.markedForDestroying = true;
            }
        }
    }
}