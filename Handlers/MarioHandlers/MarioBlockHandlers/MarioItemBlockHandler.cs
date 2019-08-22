using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioItemBlockHandler : ICollisionHandler
    {
        public IMario mario;
        public ItemBlock itemBlock;
        public int direction;
        public List<ICommand> commandList;

        public MarioItemBlockHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                itemBlock = (ItemBlock)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                itemBlock = (ItemBlock)collision.LeftSlot;
            }
            direction = (int)collision.CollisionType;
            commandList = new List<ICommand>();

            Rectangle MarioRectangle = new Rectangle(mario.XCoordinate, mario.YCoordinate, mario.Width, mario.Height);
            Rectangle ItemBlockRectangle = new Rectangle(itemBlock.XCoordinate, itemBlock.YCoordinate, itemBlock.Width, itemBlock.Height);
            Rectangle result = Rectangle.Intersect(MarioRectangle, ItemBlockRectangle);
            int deltaX = result.Right - result.Left;
            int deltaY = result.Bottom - result.Top;

            if (direction == 0)
            {
                commandList.Add(new PushMarioRightCommand(mario, deltaX));
            }
            else if (direction == 1)
            {
                commandList.Add(new PushMarioLeftCommand(mario, deltaX));
            }
            else if (direction == 2 && !GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioUpCommand(mario, deltaY));
            }
            else if (direction == 3 && !GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioDownCommand(mario, deltaY));
                commandList.Add(new ItemBlockUpdateCommand(level, itemBlock, mario));
                MusicPlayer.EffectList("powerupAppear").Play();
            }
            else if (direction == 3 && GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioDownCommand(mario, deltaY));
            }
            else if (direction == 2 && GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioUpCommand(mario, deltaY));
                commandList.Add(new ItemBlockUpdateCommand(level, itemBlock, mario));
                MusicPlayer.EffectList("powerupAppear").Play();
            }
        }

        public void Execute()
        {
            foreach (ICommand Command in commandList)
            {
                Command.Execute();
            }
        }

    }
}
