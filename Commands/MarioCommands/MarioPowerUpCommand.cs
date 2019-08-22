/*Author : David Cordle
 * Updated : July 28th
 * Version : 4.5
 * Description : Handling for when
 * Mario Recieves a Power Up
 */

namespace SuperMario
{
    class MarioPowerUpCommand : ICommand
    {
        private IMario mario;

        public MarioPowerUpCommand(IMario newMario)
        {
            mario = newMario;
        }

        public void Execute()
        {
            mario.PowerUp();
        }
    }
}