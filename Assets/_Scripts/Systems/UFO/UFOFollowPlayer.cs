using _Scripts.MonoLinks;

namespace _Scripts.Systems.UFO
{
    public class UFOFollowPlayer: IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public UFOFollowPlayer(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }


        public void Run()
        {
            if(_gameEntitiesBag.players.Length == 0) return;
            var player = _gameEntitiesBag.players[0];

            foreach (var ufo in _gameEntitiesBag.ufos)
            {
                var direction = player.transform.position - ufo.transform.position;
                ufo.Velocity = direction.normalized;
            }
        }
    }
}