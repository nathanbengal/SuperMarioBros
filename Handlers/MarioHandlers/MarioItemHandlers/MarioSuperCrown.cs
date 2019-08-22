using System;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioSuperCrown : ICollisionHandler
    {
        private IMario mario;
        private SuperCrown crown;
        private List<ICommand> commandListMario;

        public MarioSuperCrown(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is Mario)
            {
                mario = (IMario)collision.LeftSlot;
                crown = (SuperCrown)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                crown = (SuperCrown)collision.LeftSlot;
            }
            commandListMario = new List<ICommand>();

            commandListMario.Add(new DoubleJumpPowerUpCommand(mario));
            MusicPlayer.EffectList("powerup").Play();
            commandListMario.Add(new DeleteObjectCommand(level, crown));
            commandListMario.Add(new ItemScoreCommand(crown));
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