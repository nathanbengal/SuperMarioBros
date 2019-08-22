using System;
using System.Collections.Generic;

namespace SuperMario
{
    class FireballBlockHandler : ICollisionHandler
    {
        private FireBall fireBall;
        private int direction;
        private List<ICommand> commandList;

        public FireballBlockHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is FireBall)
            {
                fireBall = (FireBall)collision.LeftSlot;
            }
            else
            {
                fireBall = (FireBall)collision.RightSlot;
            }
            direction = (int)collision.CollisionType;
            commandList = new List<ICommand>();

            if (direction == 0)
            {
                commandList.Add(new DeleteObjectCommand(level, fireBall));
            }
            if (direction == 1)
            {
                commandList.Add(new DeleteObjectCommand(level, fireBall));
            }
        }

        public void Execute()
        {
            foreach (ICommand Command in commandList)
            {
                Command.Execute();
            }
            GlobalVariables.FireballCount--;
        }

    }
}
