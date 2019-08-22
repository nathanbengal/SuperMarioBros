using System;
using System.Collections.Generic;

namespace SuperMario
{
    class EnemyEnemyHandler : ICollisionHandler
    {
        private IEnemy enemy1;
        private IEnemy enemy2;
        private int direction;
        private List<ICommand> commandListKoopaGoomba;

        public EnemyEnemyHandler(CollisionObject collision, Level level)
        {

            enemy1 = (IEnemy)collision.LeftSlot;
            enemy2 = (IEnemy)collision.RightSlot;


            direction = (int)collision.CollisionType;
            commandListKoopaGoomba = new List<ICommand>();

            if (direction == 0)
            {
                if (!(enemy1.Power is StarState) && !(enemy2.Power is StarState))
                {
                    commandListKoopaGoomba.Add(new EnemyRightCommand(enemy1));
                    commandListKoopaGoomba.Add(new EnemyLeftCommand(enemy2));
                }
                
            } else
            {
                if (!(enemy1.Power is StarState) && !(enemy2.Power is StarState))
                {
                    commandListKoopaGoomba.Add(new EnemyLeftCommand(enemy1));
                    commandListKoopaGoomba.Add(new EnemyRightCommand(enemy2));
                }
                
            }
        }

        public void Execute()
        {
            foreach (ICommand Command in commandListKoopaGoomba)
            {
                Command.Execute();
            }
        }

    }
}
