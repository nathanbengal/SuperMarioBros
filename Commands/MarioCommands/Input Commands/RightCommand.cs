/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Manually
 * Switching mario into right stationary
 * or movement states.
 */
namespace SuperMario
{
    class RightCommand : ICommand
    {
        private IMario mario;
        //Constructor
        public RightCommand(IMario gameObject)
        {
            mario = gameObject;
        }

        public void Execute()
        {
            mario.RightInput();
            mario.RightMovementFlag = true;
        }
    }
}
