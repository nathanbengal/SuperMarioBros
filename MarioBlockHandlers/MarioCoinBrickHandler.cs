using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioCoinBrickHandler : ICollisionHandler
    {
        private IMario mario;
        private CoinBrick coinBrick;
        private int direction;
        private List<ICommand> commandList;

        public MarioCoinBrickHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                coinBrick = (CoinBrick)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                coinBrick = (CoinBrick)collision.LeftSlot;
            }
            direction = (int)collision.CollisionType;
            commandList = new List<ICommand>();

            Rectangle MarioRectangle = new Rectangle(mario.XCoordinate, mario.YCoordinate, mario.Width, mario.Height);
            Rectangle CoinBrickRectangle = new Rectangle(coinBrick.XCoordinate, coinBrick.YCoordinate, coinBrick.Width, coinBrick.Height);
            Rectangle result = Rectangle.Intersect(MarioRectangle, CoinBrickRectangle);
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
                commandList.Add(new CoinBrickUpdateCommand(level, coinBrick));
            }
            else if (direction == 2 && GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioUpCommand(mario, deltaY));
                commandList.Add(new CoinBrickUpdateCommand(level, coinBrick));
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
