using _Scripts.MonoLinks;

namespace _Scripts.Systems.Score
{
    public class CountScoreOnEntitesDeaths : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public CountScoreOnEntitesDeaths(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            if (_gameEntitiesBag.players.Length == 0) return;
            var player = _gameEntitiesBag.players[0];
            if (player.markedForDestroying) return;

            if (_gameEntitiesBag.scores.Length == 0) return;
            var score = _gameEntitiesBag.scores[0];

            foreach (var asteroid in _gameEntitiesBag.asteroids)
                if (asteroid.markedForDestroying)
                    score.score += 1;

            foreach (var ufo in _gameEntitiesBag.ufos)
                if (ufo.markedForDestroying)
                    score.score += 2;

            foreach (var asteroidShard in _gameEntitiesBag.asteroidShards)
                if (asteroidShard.markedForDestroying)
                    score.score += 1;
        }
    }
}