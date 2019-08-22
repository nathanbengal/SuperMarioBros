/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Manually
 * Reseting the game.
 */
namespace SuperMario
{
    class ResetCommand : ICommand
    {
        //Constructor
        public ResetCommand()
        {
            //Do Nothing
        }

        //Execute command to quit game
        public void Execute()
        {
            GlobalVariables.Reset = true;
        }
    }
}
