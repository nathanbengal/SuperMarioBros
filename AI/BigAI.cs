using System;
namespace SuperMario
{
    class BigAI : IAI
    {
        public void Update(IMario mario, IEnemy enemy)
        {
            if (mario.XCoordinate / 2 > enemy.XCoordinate / 2)
            {
                enemy.Right();
            }
            else if (mario.XCoordinate / 2 < enemy.XCoordinate / 2)
            {
                enemy.Left();
            }
        }
    }
}
