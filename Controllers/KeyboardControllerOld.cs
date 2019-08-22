/* Authors: Michael Troller
 * Version: 2.1
 * Description: Keyboard control
 * class. Stores key presses into
 * dictionary with associated command.
 */
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

/*namespace SuperMario
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> bindings = new Dictionary<Keys, ICommand>();
     
        //Sets dictionary references to key presses
        public void BindCommand(Keys key, ICommand command)
        {
            bindings.Add(key, command);
        }

        //Update method gathers pressed keys and
        //Updates necissary components using a dictionary
        public void Update()
        {
            Keys[] PressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys Key in PressedKeys)
            {
                if (bindings.Keys.Contains(Key))
                {
                    bindings[Key].Execute();
                }
            }
        }

        public void ClearKeyBindings()
        {
            bindings.Clear();
        }
    }
}*/
