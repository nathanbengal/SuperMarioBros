/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Moving mario down after a collision
 */
namespace SuperMario
{
    class PushMarioDownCommand : ICommand
    {
        private IMario mario;
        private int delta;

        public PushMarioDownCommand(IMario gameObject, int delta)
        {
            mario = gameObject;
            this.delta = delta;
        }

        //Execute as mandated by ICommand interface
        public void Execute()
        {
            mario.PushMarioDown(delta);
        }
    }
}
