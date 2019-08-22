﻿namespace SuperMario
{
    class StarState : IEnemyPowerState
    {
        public IEnemyPowerState Damage()
        {
            return this;
        }

        public IEnemyPowerState JumpShroom()
        {
            return this;
        }

        public IEnemyPowerState Mushroom()
        {
            return this;
        }

        public IEnemyPowerState Star()
        {
            return this;
        }
    }
}
