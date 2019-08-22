using System;
namespace SuperMario
{
    class StarAI : IAI
    {
        public void Update(IMario mario, IEnemy enemy)
        {
            if (mario.XCoordinate / 3 > enemy.XCoordinate / 3)
            {
                enemy.Right();
            }
            else if (mario.XCoordinate / 3 < enemy.XCoordinate / 3)
            {
                enemy.Left();
            }
            
        }
    }
}
