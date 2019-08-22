/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Moving mario down after a collision
 */
namespace SuperMario
{
    class WarpMarioCommand : ICommand
    {
        private IMario mario;
        private int deltaX;
        private int deltaY;

        public WarpMarioCommand(IMario gameObject, int deltaX, int deltaY)
        {
            mario = gameObject;
            this.deltaX = deltaX;
            this.deltaY = deltaY;

        }

        //Execute as mandated by ICommand interface
        public void Execute()
        {
            mario.XCoordinate = deltaX;
            mario.YCoordinate = deltaY;
        }
    }
}
