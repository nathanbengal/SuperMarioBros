/* Authors: Nathan Bengal, Michael Troller
 * Version: 2.1
 * Description: Commands for Updating a hidden block
 */
namespace SuperMario
{
    class HiddenBlockUpdateCommand : ICommand
    {
        private Level level;
        private HiddenBlock block;

        public HiddenBlockUpdateCommand(Level level, HiddenBlock gameObject)
        {
            this.level = level;
            block = gameObject;
        }

        //Execute Command as demanded by ICommand interface
        public void Execute()
        {
            level.ReplaceWithUsed(block);
            level.SpawnExtraLifeMushroom(block);
        }
    }
}
