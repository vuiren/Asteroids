namespace _Scripts.Entities.Spawners
{
    public abstract class Spawner : GameEntity
    {
        public bool active = true;
        public float remainingDelayBeforeSpawn;

        protected Spawner(string name = "Spawner") : base(name)
        {
        }
    }
}