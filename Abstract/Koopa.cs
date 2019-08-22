using System;

namespace SuperMario
{
    class Koopa : AbstractEnemy, IGameObject, IEnemy
    {
        public Koopa(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
            //sprite = SpriteFactory.Instance.CreateKoopaMovingLeftSprite();
            sprite = SpriteFactory.Instance.CreateKoopaMovingLeftSprite();
            width = sprite.MaxWidth;
            height = sprite.MaxHeight;
            movementState = new EnemyLeftMovementState();
            physics = new RegularPhysics(xCoordinate, yCoordinate);
            powerState = new RegularState(this);
            ai = new RegularAI();
            immuneTimer = 0;
            immune = false;
        }

        override public void Left()
        {
            if (movementState is EnemyRightMovementState)
            {
                sprite = SpriteFactory.Instance.SwitchKoopaLeft(powerState);
            }
            movementState = movementState.Left();
            physics.Left();
            
        }

        override public void Right()
        {
            if (movementState is EnemyLeftMovementState)
            {
                sprite = SpriteFactory.Instance.SwitchKoopaRight(powerState);
            }
            movementState = movementState.Right();
            physics.Right();
            
        }

        override public void PushLeft(int delta)
        {
            if (movementState is EnemyRightMovementState)
            {
                sprite = SpriteFactory.Instance.SwitchKoopaLeft(powerState);
            }
            movementState = movementState.Left();
            physics.PushLeft(delta);

        }

        override public void PushRight(int delta)
        {
            if (movementState is EnemyLeftMovementState)
            {
                sprite = SpriteFactory.Instance.SwitchKoopaRight(powerState);
            }
            movementState = movementState.Right();
            physics.PushRight(delta);
        }

        override public void LeftRun()
        {
            if (movementState is EnemyRightMovementState)
            {
                sprite = SpriteFactory.Instance.SwitchKoopaLeft(powerState);
            }
            movementState = movementState.Left();
            physics.LeftRun();

        }

        override public void RightRun()
        {
            if (movementState is EnemyLeftMovementState)
            {
                sprite = SpriteFactory.Instance.SwitchKoopaRight(powerState);
            }
            movementState = movementState.Right();
            physics.RightRun();

        }
    }
}
