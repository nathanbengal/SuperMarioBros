/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for damaging mario
 */
namespace SuperMario
{
    class MarioTakeDamageCommand : ICommand
    {
        private IMario mario;

        public MarioTakeDamageCommand(IMario gameObject)
        {
            mario = gameObject;
        }
        //Execute as mandated by ICommand interface
        public void Execute()
        {
            mario.MarioTakeDamage();
            if(mario.Power.GetType() == typeof(DeadMario) && GlobalVariables.EnableDeathCount == false)
            {
                GlobalVariables.EnableDeathCount = true;
            }
        }
    }
}
