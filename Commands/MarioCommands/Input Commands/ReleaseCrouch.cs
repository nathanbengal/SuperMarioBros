/* Authors: Michael Troller, David Cordle
 * Version: 2.1
 * Description: Commands for Manually
 * Switching mario into either stationary
 * or crouching states.
 */
namespace SuperMario
{
    class ReleaseCrouch : ICommand
    {
        private IMario mario;

        //Constructor
        public ReleaseCrouch(IMario gameObject)
        {
            mario = gameObject;
        }

        //Constructor
        public void Execute()
        {
            mario.ToIdleFromCrouch();
            mario.EnableLeftRightMove = true;
        }
    }
}