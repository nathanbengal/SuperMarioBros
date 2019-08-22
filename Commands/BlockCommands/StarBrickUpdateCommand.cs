/* Authors: Nathan Bengal, Michael Troller
 * Version: 2.1
 * Description: Command for updating a coin block
 */
namespace SuperMario
{
    class StarBrickUpdateCommand : ICommand
    {
        private StarBrick starBrick;
        private Level level;

        public StarBrickUpdateCommand(Level level, StarBrick gameObject)
        {
            this.level = level;
            starBrick = gameObject;
        }
        //Execute Command as demanded by ICommand interface
        public void Execute()
        {
            level.ReplaceWithUsed(starBrick);
            level.SpawnStar(starBrick);
        }
    }
}
