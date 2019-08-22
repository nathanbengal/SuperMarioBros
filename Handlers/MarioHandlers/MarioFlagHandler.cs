using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioFlagHandler : ICollisionHandler
    {
        private IMario mario;
        private Flag flag;
        private int deltaX;

        public MarioFlagHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                flag = (Flag)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                flag = (Flag)collision.LeftSlot;
            }
            Rectangle MarioRectangle = new Rectangle(mario.XCoordinate, mario.YCoordinate, mario.Width, mario.Height);
            Rectangle FlagRectangle = new Rectangle(flag.XCoordinate, flag.YCoordinate, flag.Width, flag.Height);
            Rectangle result = Rectangle.Intersect(MarioRectangle, FlagRectangle);
            deltaX = result.Right - result.Left;

            GlobalVariables.FlagDescend = false;
        }

        public void Execute()
        {
           mario.DescendFlag(deltaX);
        }

    }
}
