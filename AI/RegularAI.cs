namespace SuperMario
{
    class RegularAI : IAI
    {
        public void Update(IMario mario, IEnemy enemy)
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
