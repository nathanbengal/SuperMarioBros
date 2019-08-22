using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace SuperMario
{
    class EnemyBlockHandler : ICollisionHandler
    {
        private IEnemy enemy;
        private IBlock block;
        private int direction;
        private List<ICommand> commandList;

        public EnemyBlockHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IEnemy)
            {
                enemy = (IEnemy)collision.LeftSlot;
                block = (IBlock)collision.RightSlot;
            }
            else
            {
                enemy = (IEnemy)collision.RightSlot;
                block = (IBlock)collision.LeftSlot;
            }
            direction = (int)collision.CollisionType;
            commandList = new List<ICommand>();
            Rectangle MarioRectangle = new Rectangle(enemy.XCoordinate, enemy.YCoordinate, enemy.Width, enemy.Height);
            Rectangle BrickBlockRectangle = new Rectangle(block.XCoordinate, block.YCoordinate, block.Width, block.Height);
            Rectangle result = Rectangle.Intersect(MarioRectangle, BrickBlockRectangle);
            int deltaX = result.Right - result.Left;
            int deltaY = result.Bottom - result.Top;

            if (direction == 0)
            {
                commandList.Add(new EnemyPushRightCommand(enemy, deltaX));
                if (enemy.Power is StarState)
                {
                     enemy.Jump();
                }
            }
            else if (direction == 1)
            {
                commandList.Add(new EnemyPushLeftCommand(enemy, deltaX));
                if (enemy.Power is StarState)
                {
                    enemy.Jump();
                }

            }
            else if (direction == 2)
            {
                commandList.Add(new EnemyPushUpCommand(enemy, deltaY));
            }
            else if (direction == 3)
            {
                commandList.Add(new EnemyPushDownCommand(enemy, deltaY));
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
