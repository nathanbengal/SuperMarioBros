using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioHiddenBlockHandler : ICollisionHandler
    {
        public IMario mario;
        public HiddenBlock hiddenBlock;
        public int direction;
        public List<ICommand> commandList;

        public MarioHiddenBlockHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                hiddenBlock = (HiddenBlock)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                hiddenBlock = (HiddenBlock)collision.LeftSlot;
            }
            direction = (int)collision.CollisionType;
            commandList = new List<ICommand>();

            if (direction == 3 && !GlobalVariables.FlipGravity)
            {
                Rectangle MarioRectangle = new Rectangle(mario.XCoordinate, mario.YCoordinate, mario.Width, mario.Height);
                Rectangle HiddenBlockRectangle = new Rectangle(hiddenBlock.XCoordinate, hiddenBlock.YCoordinate, hiddenBlock.Width, hiddenBlock.Height);
                Rectangle result = Rectangle.Intersect(MarioRectangle, HiddenBlockRectangle);
                int deltaX = result.Right - result.Left;

                commandList.Add(new PushMarioDownCommand(mario, deltaX));
                commandList.Add(new HiddenBlockUpdateCommand(level, hiddenBlock));
            }
            else if (direction == 2 && GlobalVariables.FlipGravity)
            {
                Rectangle MarioRectangle = new Rectangle(mario.XCoordinate, mario.YCoordinate, mario.Width, mario.Height);
                Rectangle HiddenBlockRectangle = new Rectangle(hiddenBlock.XCoordinate, hiddenBlock.YCoordinate, hiddenBlock.Width, hiddenBlock.Height);
                Rectangle result = Rectangle.Intersect(MarioRectangle, HiddenBlockRectangle);
                int deltaX = result.Right - result.Left;

                commandList.Add(new PushMarioDownCommand(mario, deltaX));
                commandList.Add(new HiddenBlockUpdateCommand(level, hiddenBlock));
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
