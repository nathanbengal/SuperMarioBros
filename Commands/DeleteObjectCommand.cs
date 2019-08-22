/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for deleting a block from a level
 */
using System.Collections.Generic;

namespace SuperMario
{
    class DeleteObjectCommand : ICommand
    {
        private Level level;
        private IGameObject main;


        public DeleteObjectCommand(Level level, IGameObject gameObject)
        {
            this.level = level;
            main = gameObject;
        }

        //Execute as mandated by ICommand interface
        public void Execute()
        {
            level.Delete(main);
        }
    }
}
