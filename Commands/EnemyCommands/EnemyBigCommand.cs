/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Manually
 * Switching to Big Mario
 */
namespace SuperMario
{
    class EnemyBigCommand : ICommand
    {

        private IEnemy enemy;

        public EnemyBigCommand(IEnemy gameObject)
        {
            enemy = gameObject;
        }

        //Execute as mandated by ICommand interface
        public void Execute()
        {
            enemy.Mushroom();
        }
    }
}
