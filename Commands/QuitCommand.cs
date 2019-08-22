/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Manually
 * Quitting the game.
 */
namespace SuperMario
{
    class QuitCommand : ICommand
    {
        private MarioGame game;
        //Constructor
        public QuitCommand(MarioGame game)
        {
            this.game = game;
        }

        //Execute command to quit game
        public void Execute()
        {
            game.Exit();
        }
    }
}
