/* Author : David Cordle
 * Updated : July Sixth 2019
 * Version : 5.0
 * Description : Pauses the game
 * by blocking the update cycle
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class PauseGameCommand : ICommand
    {
        private const string SOUNDNAME = "pause";
        public PauseGameCommand()
        {
            //Do Nothing
        }

        public void Execute()
        {
            if (GlobalVariables.EnablePause)
            {
                GlobalVariables.Paused = !GlobalVariables.Paused;
                GlobalVariables.EnablePause = false;
                MusicPlayer.EffectList(SOUNDNAME).Play();
            }
        }
    }
}
