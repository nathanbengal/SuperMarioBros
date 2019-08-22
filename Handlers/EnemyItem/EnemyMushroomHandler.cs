using System;
using System.Collections.Generic;

namespace SuperMario
{
    class EnemyMushroomHandler : ICollisionHandler
    {
        private IEnemy enemy;
        private IGameObject item;
        private List<ICommand> commandList;

        public EnemyMushroomHandler(CollisionObject collision, Level level)
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

            commandList.Add(new EnemyBigCommand(enemy));
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
