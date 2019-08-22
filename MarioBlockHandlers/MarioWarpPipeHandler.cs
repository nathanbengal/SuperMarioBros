
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioWarpPipeHandler : ICollisionHandler
    {
        public IMario mario;
        public WarpPipe pipe;
        public int direction;
        public List<ICommand> commandList;

        public MarioWarpPipeHandler(CollisionObject collision, Level level, MarioGame game)
        {
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                pipe = (WarpPipe)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                pipe = (WarpPipe)collision.LeftSlot;
            }
            direction = (int)collision.CollisionType;
            commandList = new List<ICommand>();

            Rectangle MarioRectangle = new Rectangle(mario.XCoordinate, mario.YCoordinate, mario.Width, mario.Height);
            Rectangle PipeRectangle = new Rectangle(pipe.XCoordinate, pipe.YCoordinate, pipe.Width, pipe.Height);
            Rectangle result = Rectangle.Intersect(MarioRectangle, PipeRectangle);
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

                if (mario.Warpable)
                {
                    game.SwapLevel();
                    commandList.Add(new WarpMarioCommand(mario, WarpPipe.ExitX, WarpPipe.ExitY));
                    MusicPlayer.EffectList("pipe").Play();
                }


            }
            else if (direction == 3 && !GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioUpCommand(mario, deltaY));
            }
            else if (direction == 3 && GlobalVariables.FlipGravity)
            {
                commandList.Add(new PushMarioUpCommand(mario, deltaY));

                if (mario.Warpable)
                {
                    game.SwapLevel();
                    commandList.Add(new WarpMarioCommand(mario, WarpPipe.ExitX, WarpPipe.ExitY));
                    MusicPlayer.EffectList("pipe").Play();
                }


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
