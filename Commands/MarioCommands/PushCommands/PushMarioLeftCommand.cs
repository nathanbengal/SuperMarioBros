/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Moving mnario after a collision
 */
namespace SuperMario
{
    class PushMarioLeftCommand : ICommand
    {
        private IMario mario;
        private int delta;

        public PushMarioLeftCommand(IMario gameObject, int delta)
        {
            mario = gameObject;
            this.delta = delta;
        }

        //Execute as mandated by ICommand interface
        public void Execute()
        {
            mario.PushMarioLeft(delta);
        }
    }
}
