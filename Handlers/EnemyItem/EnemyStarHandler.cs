using System;
using System.Collections.Generic;

namespace SuperMario
{
    class EnemyStarHandler : ICollisionHandler
    {
        private IEnemy enemy;
        private IGameObject item;
        private List<ICommand> commandList;

        public EnemyStarHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IEnemy)
            {
                enemy = (IEnemy)collision.LeftSlot;
                item = (IGameObject)collision.RightSlot;
            }
            else
            {
                enemy = (IEnemy)collision.RightSlot;
                item = (IGameObject)collision.LeftSlot;
            }
            commandList = new List<ICommand>();

            commandList.Add(new EnemyStarCommand(enemy));
            commandList.Add(new DeleteObjectCommand(level, item));
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

