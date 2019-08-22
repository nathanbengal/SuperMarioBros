/* Author : David Cordle
 * Updated : July 8th 2019
 * Version : 5.0
 * Description : Increases the game score
 * by a set amount when an item gets collected
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class ItemScoreCommand : ICommand
    {
        private int scoreIncrease;

        public ItemScoreCommand(IGameObject item)
        {
            if(item is Coin)
            {
                scoreIncrease = 50;
                GlobalVariables.CoinCount++;
            }
            else if(item is ExtraLifeMushroom)
            {
                scoreIncrease = 100;
                GlobalVariables.FirstPlayerLives++;
            }
            else if(item is Mushroom || item is GravityOrb)
            {
                scoreIncrease = 100;
            }
            else if(item is FireFlower || item is SuperCrown)
            {
                scoreIncrease = 150;
            }
            else if(item is Star)
            {
                scoreIncrease = 200;
            }
        }

        public void Execute()
        {
            GlobalVariables.Score += scoreIncrease;
        }
    }
}
