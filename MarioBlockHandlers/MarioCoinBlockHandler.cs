using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioCoinBlockHandler : ICollisionHandler
    {
        public IMario mario;
        public CoinBlock coinBlock;
        public int direction;
        public List<ICommand> commandList;

        public MarioCoinBlockHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is Mario)
            {
                mario = (IMario)collision.LeftSlot;
                coinBlock = (CoinBlock)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                coinBlock = (CoinBlock)collision.LeftSlot;
            }
            direction = (int)collision.CollisionType;
            commandList = new List<ICommand>();

            Rectangle MarioRectangle = new Rectangle(mario.XCoordinate, mario.YCoordinate, mario.Width, mario.Height);
            Rectangle CoinBlockRectangle = new Rectangle(coinBlock.XCoordinate, coinBlock.YCoordinate, coinBlock.Width, coinBlock.Height);
            Rectangle result = Rectangle.Intersect(MarioRectangle, CoinBlockRectangle);
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
                commandList.Add(new CoinBlockUpdateCommand(level, coinBlock));
            }
            else if (direction == 2 && GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioUpCommand(mario, deltaY));
                commandList.Add(new CoinBlockUpdateCommand(level, coinBlock));
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
