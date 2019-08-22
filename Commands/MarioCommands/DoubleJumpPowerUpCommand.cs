/* Author : David Cordle
 * Updated : July 18th 2019
 * Version : 6.0
 * Description : Command for a 
 * Mario becoming a super crown
 * powerUp
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class DoubleJumpPowerUpCommand : ICommand
    {
        IMario mainMario;
        public DoubleJumpPowerUpCommand(IMario newMario)
        {
            mainMario = newMario;
        }

        public void Execute()
        {
            mainMario.PowerUpDoubleJump();
        }
    }
}
