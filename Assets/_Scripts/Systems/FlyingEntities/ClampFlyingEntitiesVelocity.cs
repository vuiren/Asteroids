using System.Linq;
using _Scripts.Data;
using _Scripts.MonoLinks;

namespace _Scripts.Systems
{
    public class ClampFlyingEntitiesVelocity : IRunSystem
    {
        private readonly Configuration _configuration;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public ClampFlyingEntitiesVelocity(Configuration configuration, GameEntitiesBag gameEntitiesBag)
        {
            _configuration = configuration;
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            foreach (var flyingEntity in _gameEntitiesBag.flyingEntities.Where(flyingEntity =>
                         flyingEntity.Velocity.magnitude > _configuration.MaxVelocity))
                flyingEntity.Velocity = flyingEntity.Velocity.normalized * _configuration.MaxVelocity;
        }
    }
}