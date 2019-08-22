using System;
using System.Collections.Generic;

namespace SuperMario
{
    class EnemyJumpHandler : ICollisionHandler
    {
        private IEnemy enemy;
        private IGameObject item;
        private List<ICommand> commandListMario;

        public EnemyJumpHandler(CollisionObject collision, Level level)
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
            commandListMario = new List<ICommand>();

            commandListMario.Add(new EnemyJumpCommand(enemy));
            commandListMario.Add(new DeleteObjectCommand(level, item));
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
