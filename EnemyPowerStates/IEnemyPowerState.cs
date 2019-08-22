namespace SuperMario
{
    public interface IEnemyPowerState
    {
        IEnemyPowerState Mushroom();
        IEnemyPowerState JumpShroom();
        IEnemyPowerState Star();
        IEnemyPowerState Damage();
    }
}
