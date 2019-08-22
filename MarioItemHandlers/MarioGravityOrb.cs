using System;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioGravityOrb: ICollisionHandler
    {
        private IMario mario;
        private GravityOrb orb;
        private List<ICommand> commandListMario;

        public MarioGravityOrb(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                orb = (GravityOrb)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                orb = (GravityOrb)collision.LeftSlot;
            }
            commandListMario = new List<ICommand>();

            commandListMario.Add(new GravityPowerUp(mario));
            MusicPlayer.EffectList("powerup").Play();
            commandListMario.Add(new DeleteObjectCommand(level, orb));
            commandListMario.Add(new ItemScoreCommand(orb));
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
