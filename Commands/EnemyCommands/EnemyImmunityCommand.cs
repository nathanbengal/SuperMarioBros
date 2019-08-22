/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Manually
 * Switching to Big Mario
 */
namespace SuperMario
{
    class EnemyImmunityCommand : ICommand
    {

        private IEnemy enemy;

        public EnemyImmunityCommand(IEnemy gameObject)
        {
            enemy = gameObject;
        }

        //Execute as mandated by ICommand interface
        public void Execute()
        {
            enemy.BecomeImmune();
        }
    }
}
