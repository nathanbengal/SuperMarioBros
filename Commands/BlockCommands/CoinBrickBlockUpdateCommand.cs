/* Authors: Nathan Bengal, Michael Troller
 * Version: 2.1
 * Description: Command for updating a coin block
 */
namespace SuperMario
{
    class CoinBrickUpdateCommand : ICommand
    {
        private CoinBrick coinBrick;
        private Level level;

        public CoinBrickUpdateCommand(Level level, CoinBrick gameObject)
        {
            this.level = level;
            coinBrick = gameObject;
        }
        //Execute Command as demanded by ICommand interface
        public void Execute()
        {
            coinBrick.Used();
            MusicPlayer.EffectList("coin").Play();
            level.SpawnCoin(coinBrick);
        }
    }
}
