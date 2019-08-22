/* Author : David Cordle
 * Updated : July 8th 2019
 * Version : 5.0
 * Description : Increases the game score
 * by a set amount when an enemy gets stomped.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class EnemyScoreCommand : ICommand
    {
        private int scoreIncrease;

        public EnemyScoreCommand(IEnemy enemy)
        {
            if (enemy is Koopa)
            {
                //Higher points for higher difficulty koopa
                scoreIncrease = 250;
            }
            else if (enemy is Goomba)
            {
                //Standard enemy points
                scoreIncrease = 150;
            }
        }

        public void Execute()
        {
            GlobalVariables.Score += scoreIncrease;
        }
    }
}
