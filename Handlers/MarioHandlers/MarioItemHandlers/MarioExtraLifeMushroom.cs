using System;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioExtraLifeMushroomHandler : ICollisionHandler
    {
        private ExtraLifeMushroom mushroom;
        private List<ICommand> commandListMario;

        public MarioExtraLifeMushroomHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                mushroom = (ExtraLifeMushroom)collision.RightSlot;
            }
            else
            {
                mushroom = (ExtraLifeMushroom)collision.LeftSlot;
            }
            commandListMario = new List<ICommand>();

            commandListMario.Add(new DeleteObjectCommand(level, mushroom));
            commandListMario.Add(new ItemScoreCommand(mushroom));
        }

        public void Execute()
        {
            foreach (ICommand Command in commandListMario)
            {
                Command.Execute();
            }
            MusicPlayer.EffectList("1-Up").Play();
        }

    }
}
