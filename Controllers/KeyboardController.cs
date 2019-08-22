/* Author : David Cordle
 * Updated : July Sixth 2019
 * Version : 5.0
 * Description : Handles Keyboard
 * user input. Uses tutorial from:
 * https://www.gamefromscratch.com/post/2015/06/28/MonoGame-Tutorial-Handling-Keyboard-Mouse-and-GamePad-Input.aspx
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;

namespace SuperMario
{
    public class KeyboardController : IController
    {
        private List<Keys> keyList;
        private Dictionary<Keys, ICommand> press;
        private Dictionary<Keys, ICommand> release;

        public KeyboardController()
        {
            keyList = new List<Keys>();
            press = new Dictionary<Keys, ICommand>();
            release = new Dictionary<Keys, ICommand>();
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (!GlobalVariables.Paused)
            {
                foreach (Keys key in keyList)
                {
                    if (state.IsKeyDown(key) && press.Keys.Contains(key))
                    {
                        press[key].Execute();
                    }
                    else if (state.IsKeyUp(key) && release.Keys.Contains(key))
                    {
                        release[key].Execute();
                    }
                }
            }
            else
            {
                if (state.IsKeyDown(GlobalVariables.PauseKey))
                {
                    press[GlobalVariables.PauseKey].Execute();
                }
                else if (state.IsKeyUp(GlobalVariables.PauseKey))
                {
                    release[GlobalVariables.PauseKey].Execute();
                }
            }
        }
        public void ClearKeyBindings()
        {
            press.Clear();
            release.Clear();
            keyList.Clear();
        }
        public void InitWASD(MarioGame mainGame, Level inUse)
        {
            Mario mainMario = (Mario)inUse.Player;

            press.Add(Keys.W, new UpCommand(mainMario));
            release.Add(Keys.W, new ManageJump(mainMario));
            keyList.Add(Keys.W);

            press.Add(Keys.S, new DownCommand(mainMario));
            release.Add(Keys.S, new ReleaseCrouch(mainMario));
            keyList.Add(Keys.S);

            press.Add(Keys.A, new LeftCommand(mainMario));
            release.Add(Keys.A, new LeftMovementFlagCommand(mainMario));
            keyList.Add(Keys.A);

            press.Add(Keys.D, new RightCommand(mainMario));
            release.Add(Keys.D, new RightMovementFlagCommand(mainMario));
            keyList.Add(Keys.D);

            press.Add(Keys.Q, new QuitCommand(mainGame));
            keyList.Add(Keys.Q);

            press.Add(Keys.R, new ResetCommand());
            keyList.Add(Keys.R);

            press.Add(Keys.L, new ShootFireCommand(mainMario, inUse));
            release.Add(Keys.L, new EnablePowerAttack(mainMario));
            keyList.Add(Keys.L);

            press.Add(Keys.P, new PauseGameCommand());
            release.Add(Keys.P, new EnablePauseCommand());
            keyList.Add(Keys.P);
        }
    }
}
