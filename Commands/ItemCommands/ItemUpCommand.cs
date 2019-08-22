/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Updating koopas
 */
namespace SuperMario
{
    class ItemUpCommand : ICommand
    {
        private IItem item;

        public ItemUpCommand(IItem gameObject)
        {
            item = gameObject;
        }
        //Execute as mandated by ICommand interface
        public void Execute()
        {
            item.Up();
        }
    }
}
