/* Authors: Michael Troller
 * Version: 2.1
 * Description: Commands for Manually
 * Switching to Big Mario
 */
namespace SuperMario
{
    class ShootFireCommand : ICommand
    {
        private IMario mario;
        private Level level;
        private string SOUNDNAME = "fireball";

        //Constructor
        public ShootFireCommand(IMario gameObject, Level level)
        {
            mario = gameObject;
            this.level = level;
        }

        //Execute. ICommand method.
        public void Execute()
        {
            if (mario.ShootFire() && mario.Power.GetType() == typeof(FireMario) && GlobalVariables.FireballCount < 2)
            {
                level.SpawnFireBall(mario);
                MusicPlayer.EffectList(SOUNDNAME).Play();
                mario.EnableAttack = false;
                GlobalVariables.FireballCount++;
            }
            if (mario.ShootFire() && mario.Power.GetType() == typeof(GravityMario))
            {
                GlobalVariables.FlipGravity = !GlobalVariables.FlipGravity;
                MusicPlayer.EffectList(SOUNDNAME).Play();
                mario.EnableAttack = false;
            }

        }
    }
}

