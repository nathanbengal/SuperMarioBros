/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Manually
 * Switching mario to either left stationary
 * or left moving states.
 */
namespace SuperMario
{
    class LeftCommand : ICommand
    {
        private IMario mario;

        //Constructor
        public LeftCommand(IMario gameObject)
        {
            mario = gameObject;
        }

        //Execute as Requested by ICommand interface
        public void Execute()
        {
            mario.LeftInput();
            mario.LeftMovementFlag = true;
        }
    }
}
