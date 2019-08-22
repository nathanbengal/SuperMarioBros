using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author : David Cordle
 * Updated : July 17th
 * Version : 5.0
 * Description : Enables Marios Double Jump
 */
namespace SuperMario
{
    public class ManageJump : ICommand
    {
        Mario mainMario;
        MarioPhysics physics;
        public ManageJump(Mario mario)
        {
            mainMario = mario;
            physics = mario.Physics;
        }

        public void Execute()
        {
            if(mainMario.Power.GetType() == typeof(Rosalina))
            {
                if (physics.JumpCount <= 1)
                {
                    physics.EnableJump = true;
                }
            }
        }
    }
}
