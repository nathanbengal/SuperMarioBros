/*Author : David Cordle
 * Updated : July 28th
 * Version : 4.5
 * Description : Handling for when
 * Mario Recieves a Power Up
 */

namespace SuperMario
{
    class MarioFlagCommand : ICommand
    {
        private IMario mario;
       //private FlagPole flag;
        //private Level level;
        private int delta;

        public MarioFlagCommand(IMario newMario, int delta)
        {
            mario = newMario;
            this.delta = delta;
            GlobalVariables.FlagDescend = true;
        }

        public void Execute()
        {
            mario.DescendFlag(delta);
            MusicPlayer.EffectList("flagpole").Play();
        }
    }
}