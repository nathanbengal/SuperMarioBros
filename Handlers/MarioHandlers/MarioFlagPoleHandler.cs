using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioFlagPoleHandler : ICollisionHandler
    {
        private IMario mario;
        private FlagPole flagPole;
        private int direction;
        private List<ICommand> commandList;
        private Level level;

        public MarioFlagPoleHandler(CollisionObject collision, Level level)
        {
            this.level = level;
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                flagPole = (FlagPole)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                flagPole = (FlagPole)collision.LeftSlot;
            }
            direction = (int)collision.CollisionType;
            commandList = new List<ICommand>();
            Rectangle MarioRectangle = new Rectangle(mario.XCoordinate, mario.YCoordinate, mario.Width, mario.Height);
            Rectangle FlagRectangle = new Rectangle(flagPole.XCoordinate, flagPole.YCoordinate, flagPole.Width, flagPole.Height);
            Rectangle result = Rectangle.Intersect(MarioRectangle, FlagRectangle);
            int deltaX = result.Right - result.Left;


            if (mario is StarMario)
            {
                mario.WalkToCastle();
            }
            if (direction == 1)
            {
                commandList.Add(new MarioFlagCommand(mario, deltaX));
            }
            GlobalVariables.EnableKeyboard = false;
        }

        public void Execute()
        {
            level.MoveToBackground(flagPole);
            foreach (ICommand Command in commandList)
            {
                Command.Execute();
            }
        }

    }
}
