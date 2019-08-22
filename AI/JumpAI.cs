using System;
namespace SuperMario
{
    class JumpAI : IAI
    {
        public void Update(IMario mario, IEnemy enemy)
        {
            bool SmartX = Math.Abs(mario.XCoordinate - enemy.XCoordinate) < 64;
            bool SmartY = Math.Abs((mario.YCoordinate + mario.Height) - (enemy.YCoordinate + enemy.Height)) < 48;
            if (!SmartX)
            {
                if (enemy.MovementState is EnemyLeftMovementState)
                {
                    enemy.Left();
                }
                else
                {
                    enemy.Right();
                }
            }
            else
            {
                if (!SmartY)
                {
                    enemy.Jump();
                    if (mario.Velocity[0] > 0)
                    {
                        enemy.RightRun();
                    }
                    else
                    {
                        enemy.LeftRun();
                    }
                }
                else
                {
                    if (enemy.MovementState is EnemyLeftMovementState)
                    {
                        enemy.Left();
                    }
                    else
                    {
                        enemy.Right();
                    }
                }
            }
        }
    }
}
