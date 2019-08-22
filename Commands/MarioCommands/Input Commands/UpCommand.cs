/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Manually
 * Switching to Big Mario
 */
namespace SuperMario
{
    class UpCommand : ICommand
    {
        private IMario mario;

        //Constructor
        public UpCommand(IMario gameObject)
        {
            mario = gameObject;
        }

        //Execute. ICommand method.
        public void Execute()
        {
            mario.UpInput();
        }
    }
}

