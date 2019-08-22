using System;
using System.Collections.Generic;

namespace SuperMario
{
    class ItemBlockHandler : ICollisionHandler
    {
        private IItem item;
        private int direction;
        private List<ICommand> commandList;

        public ItemBlockHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IItem)
            {
                item = (IItem)collision.LeftSlot;
            }
            else
            {
                item = (IItem)collision.RightSlot;
            }
            direction = (int)collision.CollisionType;
            commandList = new List<ICommand>();

            if (direction == 0)
            {
                commandList.Add(new ItemRightCommand(item));
            }
            else if (direction == 1)
            {
                commandList.Add(new ItemLeftCommand(item));
            }
            else if (direction == 2)
            {
                commandList.Add(new ItemUpCommand(item));
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
