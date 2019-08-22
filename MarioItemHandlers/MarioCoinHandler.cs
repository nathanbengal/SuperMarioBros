using System;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioCoinHandler : ICollisionHandler
    {
        private Coin coin;
        private List<ICommand> commandListMario;
        private const string SOUNDNAME = "coin";

        public MarioCoinHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                coin = (Coin)collision.RightSlot;
            }
            else
            {
                coin = (Coin)collision.LeftSlot;
            }
            commandListMario = new List<ICommand>();

            commandListMario.Add(new DeleteObjectCommand(level, coin));
            commandListMario.Add(new ItemScoreCommand(coin));
        }

        public void Execute()
        {
            foreach (ICommand Command in commandListMario)
            {
                Command.Execute();
            }
            MusicPlayer.EffectList(SOUNDNAME).Play();
        }

    }
}
