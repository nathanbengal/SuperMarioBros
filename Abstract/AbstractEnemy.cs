namespace SuperMario
{
    abstract class AbstractEnemy : IEnemy
    {
        protected ISprite sprite;
        protected IEnemyPhysics physics;
        protected IEnemyPowerState powerState;
        protected IEnemyMovementState movementState;
        protected IAI ai;
        protected int xCoordinate;
        protected int yCoordinate;
        protected int width;
        protected int height;
        protected int immuneTimer;
        protected bool immune;

        private int TEMPTIMER = 100;

        public IEnemyPhysics Physics
        {
            get
            {
                return physics;
            }
            set
            {
                physics = value;
            }
        }

        public ISprite Sprite
        {
            get
            {
                return sprite;
            }
            set
            {
                sprite = value;
            }
        }

        public IAI AI
        {
            get
            {
                return AI;
            }
            set
            {
                ai = value;
            }
        }

        public IEnemyMovementState MovementState
        {
            get
            {
                return movementState;
            }
        }

        public bool Immune
        {
            get
            {
                return immune;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }
        public int XCoordinate
        {
            get
            {
                return xCoordinate;
            }

        }

        public int YCoordinate
        {
            get
            {
                return yCoordinate;
            }
            set
            {
                yCoordinate = value;
            }
        }


        public IEnemyPowerState Power
        {
            get
            {
                return powerState;
            }
        }



        //Methods
        public void Stomp()
        {
            powerState = powerState.Damage();
            width = sprite.MaxWidth;
            height = sprite.MaxHeight;
        }

        public void BecomeImmune()
        {
            immune = true;
            immuneTimer = GlobalVariables.ImmuneTimer;
        }

        public void Draw()
        {
            sprite.Draw(xCoordinate, yCoordinate);
        }

        public void Update()
        {
            /* This is in update so that the goomba will move automatically without any help from user input */
            if (immuneTimer > 0)
            {
                immuneTimer--;
            }
            else
            {
                immune = false;
            }

            TEMPTIMER--;

            ai.Update(Level.GetPlayer, this);
            physics.Update();

            int[] pos = physics.GetPosition;
            xCoordinate = pos[0];
            yCoordinate = pos[1];

            sprite.Update();
        }

        virtual public void Left()
        {
            movementState = movementState.Left();
            physics.Left();
        }

        virtual public void Right()
        {
            movementState = movementState.Right();
            physics.Right();
        }

        virtual public void LeftRun()
        {
            movementState = movementState.Left();
            physics.LeftRun();
        }

        virtual public void RightRun()
        {
            movementState = movementState.Right();
            physics.RightRun();
        }



        virtual public void Jump()
        {
            physics.Jump();
        }

        virtual public void PushUp(int delta)
        {
            physics.PushUp(delta);
            int[] pos = physics.GetPosition;
            xCoordinate = pos[0];
            yCoordinate = pos[1];
        }

        virtual public void PushDown(int delta)
        {
            physics.PushDown(delta);
            int[] pos = physics.GetPosition;
            xCoordinate = pos[0];
            yCoordinate = pos[1];
        }

        virtual public void PushLeft(int delta)
        {
            movementState = movementState.Left();
            physics.PushLeft(delta);
            int[] pos = physics.GetPosition;
            xCoordinate = pos[0];
            yCoordinate = pos[1];
        }

        virtual public void PushRight(int delta)
        {
            movementState = movementState.Right();
            physics.PushRight(delta);
            int[] pos = physics.GetPosition;
            xCoordinate = pos[0];
            yCoordinate = pos[1];
        }

        public void Mushroom()
        {
            powerState = powerState.Mushroom();
            width = sprite.MaxWidth;
            height = sprite.MaxHeight;
        }

        public void Star()
        {
            powerState = powerState.Star();
            width = sprite.MaxWidth;
            height = sprite.MaxHeight;
        }

        public void JumpShroom()
        {
            powerState = powerState.JumpShroom();
            width = sprite.MaxWidth;
            height = sprite.MaxHeight;
        }




    }
}
