using System;
using System.Collections.Generic;

namespace SuperMario
{
    class FireballEnemyHandler : ICollisionHandler
    {
        private FireBall fireBall;
        private IEnemy enemy;
        private List<ICommand> commandList;

        public FireballEnemyHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is FireBall)
            {
                fireBall = (FireBall)collision.LeftSlot;
                enemy = (IEnemy)collision.RightSlot;
            }
            else
            {
                fireBall = (FireBall)collision.RightSlot;
                enemy = (IEnemy)collision.LeftSlot;
            }
            commandList = new List<ICommand>();

            commandList.Add(new DeleteObjectCommand(level, fireBall));
            commandList.Add(new StompEnemyCommand(level, enemy));
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
