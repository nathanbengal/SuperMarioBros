using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioStarBrickHandler : ICollisionHandler
    {
        public IMario mario;
        public StarBrick starBrick;
        public int direction;
        public List<ICommand> commandList;

        public MarioStarBrickHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                starBrick = (StarBrick)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                starBrick = (StarBrick)collision.LeftSlot;
            }
            direction = (int)collision.CollisionType;
            commandList = new List<ICommand>();

            Rectangle MarioRectangle = new Rectangle(mario.XCoordinate, mario.YCoordinate, mario.Width, mario.Height);
            Rectangle StarBlockRectangle = new Rectangle(starBrick.XCoordinate, starBrick.YCoordinate, starBrick.Width, starBrick.Height);
            Rectangle result = Rectangle.Intersect(MarioRectangle, StarBlockRectangle);
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
                commandList.Add(new StarBrickUpdateCommand(level, starBrick));
                MusicPlayer.EffectList("powerupAppear").Play();
            }
            else if (direction == 3 && GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioDownCommand(mario, deltaY));
            }
            else if (direction == 2 && GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioUpCommand(mario, deltaY));
                commandList.Add(new StarBrickUpdateCommand(level, starBrick));
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
