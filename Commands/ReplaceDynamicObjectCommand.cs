/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for deleting a block from a level
 */
using System.Collections.Generic;

namespace SuperMario
{
    class ReplaceDynamicObjectCommand : ICommand
    {
        private Level level;
        private IGameObject oldObject;
        private IGameObject newObject;


        public ReplaceDynamicObjectCommand(Level level, IGameObject oldObject, IGameObject newObject)
        {
            this.level = level;
            this.oldObject = oldObject;
            this.newObject = newObject;
        }

        //Execute as mandated by ICommand interface
        public void Execute()
        {
            level.ReplaceDynamicObject(oldObject, newObject);
        }
    }
}
