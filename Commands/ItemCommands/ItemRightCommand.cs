/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Updating koopas
 */
namespace SuperMario
{
    class ItemRightCommand : ICommand
    {
        private IItem item;

        public ItemRightCommand(IItem gameObject)
        {
            item = gameObject;
        }
        //Execute as mandated by ICommand interface
        public void Execute()
        {
            item.Right();
        }
    }
}
