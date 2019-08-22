using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioBlockHandler : ICollisionHandler
    {
        private IMario mario;
        private IBlock block;
        private int direction;
        private List<ICommand> commandList;

        public MarioBlockHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                block = (IBlock)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                block = (IBlock)collision.LeftSlot;
            }
            direction = (int)collision.CollisionType;
            commandList = new List<ICommand>();
            Rectangle MarioRectangle = new Rectangle(mario.XCoordinate, mario.YCoordinate, mario.Width, mario.Height);
            Rectangle BrickBlockRectangle = new Rectangle(block.XCoordinate, block.YCoordinate, block.Width, block.Height);
            Rectangle result = Rectangle.Intersect(MarioRectangle, BrickBlockRectangle);
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
                commandList.Add(new BumpBlockCommand(block));
            }
            else if (direction == 2 && GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioUpCommand(mario, deltaY));
                commandList.Add(new BumpBlockCommand(block));
            }
            else if (direction == 3 && GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioDownCommand(mario, deltaY));
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
