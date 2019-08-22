/* Author : David Cordle
 * Updated : July 20th 2019
 * Version : 6.0
 * Description : Command for a 
 * Mario becoming a Gravity Mario
 * powerUp
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class GravityPowerUp : ICommand
    {
        IMario mainMario;
        public GravityPowerUp(IMario newMario)
        {
            mainMario = newMario;
        }

        public void Execute()
        {
            mainMario.PowerUpGravity();
        }
    }
}