/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Manually
 * Switching mario into either stationary
 * or crouching states.
 */
namespace SuperMario
{
    class DownCommand : ICommand
    {
        private IMario mario;

        //Constructor
        public DownCommand(IMario gameObject)
        {
            mario = gameObject;
        }
        //Constructor
        public void Execute()
        {
            mario.DownInput();

        }
    }
}
