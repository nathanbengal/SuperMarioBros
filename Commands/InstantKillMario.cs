/* Author: David Cordle
 * Updated: June 27th 2019
 * Version: 4.5
 * Description: Instant death
 * for mario whenever he falls off
 * the screen
 */
namespace SuperMario
{ 
    class InstantKillMario : ICommand
    {
        private IMario mario;
        private int xCoordinate;
        private int yCoordinate;

        public InstantKillMario(IMario newMario, int newX, int newY)
        {
            mario = newMario;
            xCoordinate = newX;
            yCoordinate = newY;
        }
    
        public void Execute()
        {
            mario.XCoordinate = xCoordinate;
            mario.YCoordinate = yCoordinate;
            mario.KillMario();
            GlobalVariables.EnableDeathCount = true;
        }
    }
}
