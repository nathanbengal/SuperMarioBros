using System;
using System.Collections.Generic;

namespace SuperMario
{
    class MarioStarHandler : ICollisionHandler
    {
        private IMario mario;
        private Star star;
        private List<ICommand> commandListMario;

        public MarioStarHandler(CollisionObject collision, Level level)
        {
            if (collision.LeftSlot is IMario)
            {
                mario = (IMario)collision.LeftSlot;
                star = (Star)collision.RightSlot;
            }
            else
            {
                mario = (IMario)collision.RightSlot;
                star = (Star)collision.LeftSlot;
            }
            commandListMario = new List<ICommand>();





            //commandListMario.Add(new StarMarioCommand(level, mario));
            commandListMario.Add(new DeleteObjectCommand(level, star));
            if (mario is Mario)
            {
                commandListMario.Add(new ReplaceDynamicObjectCommand(level, mario as IGameObject, new StarMario(mario as Mario, level)));
            }
            commandListMario.Add(new ItemScoreCommand(star));
        }

        public void Execute()
        {
            foreach (ICommand Command in commandListMario)
            {
                Command.Execute();
            }
            MusicPlayer.PlaySong("starman");
        }

    }
}
