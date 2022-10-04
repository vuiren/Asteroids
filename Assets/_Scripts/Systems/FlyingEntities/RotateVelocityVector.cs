using _Scripts.MonoLinks;

namespace _Scripts.Systems
{
    public class RotateVelocityVector : IRunSystem
    {
        private readonly GameEntitiesBag _gameEntitiesBag;

        public RotateVelocityVector(GameEntitiesBag gameEntitiesBag)
        {
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            foreach (var flyingEntity in _gameEntitiesBag.flyingEntities)
                flyingEntity.Velocity = flyingEntity.transform.InverseTransformVector(flyingEntity.Velocity);
        }
    }
}