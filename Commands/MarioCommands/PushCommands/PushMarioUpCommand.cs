/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Moving mario up after a collision
 */
namespace SuperMario
{
    class PushMarioUpCommand : ICommand
    {
        private IMario mario;
        private int delta;

        public PushMarioUpCommand(IMario gameObject, int delta)
        {
            mario = gameObject;
            this.delta = delta;
        }

        //Execute as mandated by ICommand interface
        public void Execute()
        {
            mario.PushMarioUp(delta);
        }
    }
}
