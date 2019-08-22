/* Authors: Nathan Bengal, Michael Troller
 * Version: 2.1
 * Description: Commands for updating an item block
 */
using System;

namespace SuperMario
{
    class ItemBlockUpdateCommand : ICommand
    {
        private ItemBlock itemBlock;
        private Level level;
        bool mushroom;

        public ItemBlockUpdateCommand(Level level, ItemBlock gameObject, IMario player)
        {
            mushroom = false;
            this.level = level;
            this.itemBlock = gameObject;
            IMario mario = player;
            IMarioPower powerUp = mario.Power;
            if (powerUp is SmallMario)
            {
                mushroom = true;
            }
        }

        //Execute Command as demanded by ICommand interface
        public void Execute()
        {
            level.ReplaceWithUsed(itemBlock);
            if (mushroom)
                level.SpawnMushroom(itemBlock);
            else
            {
                Random random = new Random();
                int number = random.Next(1, 12);
                //if (number <= 4)
                //{
                //    level.SpawnFireFlower(itemBlock);
                //}
                if (number <= 6)
                {
                    level.SpawnGravityOrb(itemBlock);
                }
                else
                {
                    level.SpawnSuperCrown(itemBlock);
                }
            }
        }
    }
}
