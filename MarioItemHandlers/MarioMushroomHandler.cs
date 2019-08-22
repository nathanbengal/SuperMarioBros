using System;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioMushroomHandler : ICollisionHandler
    {
        private IMario mario;
        private Mushroom mushroom;
        private List<ICommand> commandListMario;

        public MarioMushroomHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                mushroom = (Mushroom)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                mushroom = (Mushroom)collision.LeftSlot;
            }
            commandListMario = new List<ICommand>();

            commandListMario.Add(new MarioPowerUpCommand(mario));
            MusicPlayer.EffectList("powerup").Play();
            commandListMario.Add(new DeleteObjectCommand(level, mushroom));
            commandListMario.Add(new ItemScoreCommand(mushroom));
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
