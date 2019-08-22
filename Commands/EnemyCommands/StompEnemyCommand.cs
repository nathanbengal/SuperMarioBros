/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Manually
 * Switching to Big Mario
 */
namespace SuperMario
{
    class StompEnemyCommand : ICommand
    {
        private Level level;
        private IEnemy enemy;
        private const string SOUNDNAME = "stomp";

        public StompEnemyCommand(Level level, IEnemy gameObject)
        {
            this.level = level;
            enemy = gameObject;
        }

        //Execute as mandated by ICommand interface
        public void Execute()
        {
            enemy.Stomp();
            if (enemy.Power is DeadState)
            {
                level.MoveToBackground(enemy as IGameObject);
            }
            MusicPlayer.EffectList(SOUNDNAME).Play();
        }
    }
}
