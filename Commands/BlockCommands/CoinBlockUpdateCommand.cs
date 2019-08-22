/* Authors: Nathan Bengal, Michael Troller
 * Version: 2.1
 * Description: Command for updating a coin block
 */
namespace SuperMario
{
    class CoinBlockUpdateCommand : ICommand
    {
        private CoinBlock coinBlock;
        private Level level;

        public CoinBlockUpdateCommand(Level level, CoinBlock gameObject)
        {
            this.level = level;
            coinBlock = gameObject;
        }
        //Execute Command as demanded by ICommand interface
        public void Execute()
        {
            level.ReplaceWithUsed(coinBlock);
            MusicPlayer.EffectList("coin").Play();
            level.SpawnCoin(coinBlock);
        }
    }
}
