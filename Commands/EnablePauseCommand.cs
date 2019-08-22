/* Author : David Cordle
 * Updated : July Sixth 2019
 * Version : 5.0
 * Description : Enable The pause button
 * to be pressed again, call when key is up.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class EnablePauseCommand : ICommand
    {
        public EnablePauseCommand()
        {
            //Do Nothing
        }

        public void Execute()
        {
            GlobalVariables.EnablePause = true;
        }
    }
}
