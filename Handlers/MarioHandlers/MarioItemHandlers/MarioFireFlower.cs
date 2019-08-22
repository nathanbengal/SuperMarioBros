using System;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioFireFlowerHandler : ICollisionHandler
    {
        private IMario mario;
        private FireFlower fireflower;
        private List<ICommand> commandListMario;

        public MarioFireFlowerHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is Mario)
            {
                mario = (IMario)collision.LeftSlot;
                fireflower = (FireFlower)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                fireflower = (FireFlower)collision.LeftSlot;
            }
            commandListMario = new List<ICommand>();

            commandListMario.Add(new MarioPowerUpCommand(mario));
            MusicPlayer.EffectList("powerup").Play();
            commandListMario.Add(new DeleteObjectCommand(level, fireflower));
            commandListMario.Add(new ItemScoreCommand(fireflower));
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
