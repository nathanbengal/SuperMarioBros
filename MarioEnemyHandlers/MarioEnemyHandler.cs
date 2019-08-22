using System;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioEnemyHandler : ICollisionHandler
    {
        private IMario mario;
        private IEnemy enemy;
        private int direction;
        private List<ICommand> commandListMario;

        public MarioEnemyHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                enemy = (IEnemy)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                enemy = (IEnemy)collision.LeftSlot;
            }
            direction = (int)collision.CollisionType;
            commandListMario = new List<ICommand>();

            if (mario is StarMario)
            {
                commandListMario.Add(new StompEnemyCommand(level, enemy));
                commandListMario.Add(new EnemyScoreCommand(enemy));
            }
            else
            {
                

                if (direction == 0)
                {
                    commandListMario.Add(new MarioTakeDamageCommand(mario));
                    commandListMario.Add(new EnemyImmunityCommand(enemy));
                    commandListMario.Add(new EnemyLeftCommand(enemy));
                }
                else if (direction == 1)
                {
                    commandListMario.Add(new MarioTakeDamageCommand(mario));
                    commandListMario.Add(new EnemyImmunityCommand(enemy));
                    commandListMario.Add(new EnemyRightCommand(enemy));
                }
                else if (direction == 2)
                {
                    if (enemy.Power is StarState)
                    {
                        commandListMario.Add(new MarioTakeDamageCommand(mario));
                    }
                    else if (!enemy.Immune)
                    {
                        commandListMario.Add(new StompEnemyCommand(level, enemy));
                        commandListMario.Add(new BounceCommand(mario));
                        commandListMario.Add(new EnemyScoreCommand(enemy));
                    }

                }
                else if (direction == 3)
                {
                    commandListMario.Add(new MarioTakeDamageCommand(mario));
                    commandListMario.Add(new EnemyImmunityCommand(enemy));
                }
            }  
        }

        public void Execute()
        {
            foreach (ICommand Command in commandListMario)
            {
                Command.Execute();
            }
        }

    }
}
