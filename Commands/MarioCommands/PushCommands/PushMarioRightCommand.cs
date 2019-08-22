/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Moving mario right after a collision
 */
namespace SuperMario
{
    class PushMarioRightCommand : ICommand
    {
        private IMario mario;
        private int delta;

        public PushMarioRightCommand(IMario gameObject, int delta)
        {
            mario = gameObject;
            this.delta = delta;
        }

        //Execute as mandated by ICommand interface
        public void Execute()
        {
            mario.PushMarioRight(delta);
        }
    }
}
