/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Updating koopas
 */
namespace SuperMario
{
    class ItemLeftCommand : ICommand
    {
        private IItem item;

        public ItemLeftCommand(IItem gameObject)
        {
            item = gameObject;
        }
        //Execute as mandated by ICommand interface
        public void Execute()
        {
            item.Left();
        }
    }
}
