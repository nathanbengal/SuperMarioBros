/* Authors: David, Nathan, Michael
 * Team: ThreeOfAKind
 * Updated: May 25th 2019
 * Description: Parent mario class. Handles Movement
 * type actions.
 */
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace SuperMario
{
    class SpriteFactory
    {
        private static SpriteFactory instance = new SpriteFactory();
        private SpriteBatch spriteBatch;

        private SpriteFactory(){}

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public SpriteBatch SpriteBatch
        {
            set
            {
                spriteBatch = value;
            }
        }



        public ISprite CreateCoinSprite()
        {
            return new SpriteMachine(spriteBatch, "Coin");
        }

        public ISprite CreateExtraLifeMushroomSprite()
        {
            return new SpriteMachine(spriteBatch, "ExtraLifeMushroom");
        }

        public ISprite CreateFireFlowerSprite()
        {
            return new SpriteMachine(spriteBatch, "FireFlower");
        }

        public ISprite CreateGoombaSprite()
        {
            return new SpriteMachine(spriteBatch, "Goomba");
        }



        public ISprite CreateKoopaMovingLeftSprite()
        {
            return new SpriteMachine(spriteBatch, "KoopaMovingLeft");
        }




        public ISprite CreateMushroomSprite()
        {
            return new SpriteMachine(spriteBatch, "Mushroom");
        }

        public ISprite CreateGravityOrbSprite()
        {
            return new SpriteMachine(spriteBatch, "GravityOrb");
        }

        public ISprite CreateSuperCrownSprite()
        {
            return new SpriteMachine(spriteBatch, "SuperCrown");
        }

        public ISprite CreateStarSprite()
        {
            return new  SpriteMachine(spriteBatch, "Star");
        }

        public ISprite ParseSprite(Mario mario)
        {
            if(mario.Power.GetType() == typeof(DeadMario))
            {
                return CreateDeadMarioSprite();
            }

            Dictionary<Type, ISprite> main = new Dictionary<Type, ISprite>();
            main.Add(typeof(MarioLeftCrouchState), CreateMarioLeftCrouchSprite(mario.Power.GetType()));
            main.Add(typeof(MarioLeftIdleState), CreateMarioLeftIdleSprite(mario.Power.GetType()));
            main.Add(typeof(MarioLeftMovingState), CreateMarioLeftMovingSprite(mario.Power.GetType()));
            main.Add(typeof(MarioLeftJumpState), CreateMarioLeftJumpSprite(mario.Power.GetType()));
            main.Add(typeof(MarioRightCrouchState), CreateMarioRightCrouchSprite(mario.Power.GetType()));
            main.Add(typeof(MarioRightIdleState), CreateMarioRightIdleSprite(mario.Power.GetType()));
            main.Add(typeof(MarioRightMovingState), CreateMarioRightMovingSprite(mario.Power.GetType()));
            main.Add(typeof(MarioRightJumpState), CreateMarioRightJumpSprite(mario.Power.GetType()));
            main.Add(typeof(MarioLeftAttackState), CreateMarioLeftShootFireSprite());
            main.Add(typeof(MarioRightAttackState), CreateMarioRightShootFireSprite());
            main.Add(typeof(MarioLeftDescendFlagState), CreateMarioLeftDescendFlagSprite(mario.Power.GetType()));
            main.Add(typeof(MarioRightDescendFlagState), CreateMarioRightDescendFlagSprite(mario.Power.GetType()));
            Type temp = mario.State.GetType();
            return main[temp];
        }

        public ISprite CreateMarioRightIdleSprite(Type curr)
        {
            Dictionary<Type, ISprite> RightIdle = new Dictionary<Type, ISprite>();
            RightIdle.Add(typeof(SmallMario), new SpriteMachine(spriteBatch, "SmallMarioRightIdle"));
            RightIdle.Add(typeof(BigMario), new SpriteMachine(spriteBatch, "BigMarioRightIdle"));
            RightIdle.Add(typeof(FireMario), new SpriteMachine(spriteBatch, "FireMarioRightIdle"));

            RightIdle.Add(typeof(Rosalina), new SpriteMachine(spriteBatch, "RosalinaRightIdle"));
            RightIdle.Add(typeof(GravityMario), new SpriteMachine(spriteBatch, "GravityRightIdle"));

            return RightIdle[curr];
        }

        public ISprite CreateMarioRightMovingSprite(Type curr)
        {
            Dictionary<Type, ISprite> RightMoving = new Dictionary<Type, ISprite>();
            RightMoving.Add(typeof(SmallMario), new SpriteMachine(spriteBatch, "SmallMarioRightMoving"));
            RightMoving.Add(typeof(BigMario), new SpriteMachine(spriteBatch, "BigMarioRightMoving"));
            RightMoving.Add(typeof(FireMario), new SpriteMachine(spriteBatch, "FireMarioRightMoving"));

            RightMoving.Add(typeof(Rosalina), new SpriteMachine(spriteBatch, "RosalinaRightMoving"));
            RightMoving.Add(typeof(GravityMario), new SpriteMachine(spriteBatch, "GravityRightMoving"));

            return RightMoving[curr];
        }

        public ISprite CreateMarioRightJumpSprite(Type curr)
        {
            Dictionary<Type, ISprite> RightJump = new Dictionary<Type, ISprite>();
            RightJump.Add(typeof(SmallMario), new SpriteMachine(spriteBatch, "SmallMarioRightJump"));
            RightJump.Add(typeof(BigMario), new SpriteMachine(spriteBatch, "BigMarioRightJump"));
            RightJump.Add(typeof(FireMario), new SpriteMachine(spriteBatch, "FireMarioRightJump"));

            RightJump.Add(typeof(Rosalina), new SpriteMachine(spriteBatch, "RosalinaRightJump"));
            RightJump.Add(typeof(GravityMario), new SpriteMachine(spriteBatch, "GravityRightJump"));

            return RightJump[curr];
        }

        public ISprite CreateMarioRightCrouchSprite(Type curr)
        {
            Dictionary<Type, ISprite> RightCrouch = new Dictionary<Type, ISprite>();
            RightCrouch.Add(typeof(BigMario), new SpriteMachine(spriteBatch, "BigMarioRightCrouch"));
            RightCrouch.Add(typeof(FireMario), new SpriteMachine(spriteBatch, "FireMarioRightCrouch"));
            //for compilation, never used
            RightCrouch.Add(typeof(SmallMario), new SpriteMachine(spriteBatch, "FireMarioRightCrouch"));

            RightCrouch.Add(typeof(Rosalina), new SpriteMachine(spriteBatch, "RosalinaRightCrouch"));
            RightCrouch.Add(typeof(GravityMario), new SpriteMachine(spriteBatch, "GravityRightCrouch"));

            return RightCrouch[curr];
        }

        public ISprite CreateMarioLeftIdleSprite(Type curr)
        {
            Dictionary<Type, ISprite> LeftIdle = new Dictionary<Type, ISprite>();
            LeftIdle.Add(typeof(SmallMario), new SpriteMachine(spriteBatch, "SmallMarioLeftIdle"));
            LeftIdle.Add(typeof(BigMario), new SpriteMachine(spriteBatch, "BigMarioLeftIdle"));
            LeftIdle.Add(typeof(FireMario), new SpriteMachine(spriteBatch, "FireMarioLeftIdle"));

            LeftIdle.Add(typeof(Rosalina), new SpriteMachine(spriteBatch, "RosalinaLeftIdle"));
            LeftIdle.Add(typeof(GravityMario), new SpriteMachine(spriteBatch, "GravityLeftIdle"));

            return LeftIdle[curr];
        }

        public ISprite CreateMarioLeftMovingSprite(Type curr)
        {
            Dictionary<Type, ISprite> LeftMoving = new Dictionary<Type, ISprite>();
            LeftMoving.Add(typeof(SmallMario), new SpriteMachine(spriteBatch, "SmallMarioLeftMoving"));
            LeftMoving.Add(typeof(BigMario), new SpriteMachine(spriteBatch, "BigMarioLeftMoving"));
            LeftMoving.Add(typeof(FireMario), new SpriteMachine(spriteBatch, "FireMarioLeftMoving"));

            LeftMoving.Add(typeof(Rosalina), new SpriteMachine(spriteBatch, "RosalinaLeftMoving"));
            LeftMoving.Add(typeof(GravityMario), new SpriteMachine(spriteBatch, "GravityLeftMoving"));

            return LeftMoving[curr];
        }

        public ISprite CreateMarioLeftJumpSprite(Type curr)
        {
            Dictionary<Type, ISprite> LeftJump = new Dictionary<Type, ISprite>();
            LeftJump.Add(typeof(SmallMario), new SpriteMachine(spriteBatch, "SmallMarioLeftJump"));
            LeftJump.Add(typeof(BigMario), new SpriteMachine(spriteBatch, "BigMarioLeftJump"));
            LeftJump.Add(typeof(FireMario), new SpriteMachine(spriteBatch, "FireMarioLeftJump"));

            LeftJump.Add(typeof(Rosalina), new SpriteMachine(spriteBatch, "RosalinaLeftJump"));
            LeftJump.Add(typeof(GravityMario), new SpriteMachine(spriteBatch, "GravityLeftJump"));

            return LeftJump[curr];
        }

        public ISprite CreateMarioLeftCrouchSprite(Type curr)
        {
            Dictionary<Type, ISprite> LeftCrouch = new Dictionary<Type, ISprite>();
            LeftCrouch.Add(typeof(BigMario), new SpriteMachine(spriteBatch, "BigMarioLeftCrouch"));
            LeftCrouch.Add(typeof(FireMario), new SpriteMachine(spriteBatch, "FireMarioLeftCrouch"));
            //for compilation, never used
            LeftCrouch.Add(typeof(SmallMario), new SpriteMachine(spriteBatch, "FireMarioLeftCrouch"));

            LeftCrouch.Add(typeof(Rosalina), new SpriteMachine(spriteBatch, "RosalinaLeftCrouch"));
            LeftCrouch.Add(typeof(GravityMario), new SpriteMachine(spriteBatch, "GravityLeftCrouch"));

            return LeftCrouch[curr];
        }

        public ISprite CreateMarioLeftShootFireSprite()
        {
            return new SpriteMachine(spriteBatch, "FireMarioLeftShootFire");
        }

        public ISprite CreateMarioRightShootFireSprite()
        {
            return new SpriteMachine(spriteBatch, "FireMarioRightShootFire");
        }



        public ISprite ParseStarSprite(StarMario mario)
        {
            if (mario.Power.GetType() == typeof(DeadMario))
            {
                return CreateDeadMarioSprite();
            }
            Dictionary<Type, ISprite> main = new Dictionary<Type, ISprite>();
            main.Add(typeof(MarioLeftCrouchState), CreateStarMarioLeftCrouchSprite(mario.Power.GetType()));
            main.Add(typeof(MarioLeftIdleState), CreateStarMarioLeftIdleSprite(mario.Power.GetType()));
            main.Add(typeof(MarioLeftMovingState), CreateStarMarioLeftMovingSprite(mario.Power.GetType()));
            main.Add(typeof(MarioLeftJumpState), CreateStarMarioLeftJumpSprite(mario.Power.GetType()));
            main.Add(typeof(MarioRightCrouchState), CreateStarMarioRightCrouchSprite(mario.Power.GetType()));
            main.Add(typeof(MarioRightIdleState), CreateStarMarioRightIdleSprite(mario.Power.GetType()));
            main.Add(typeof(MarioRightMovingState), CreateStarMarioRightMovingSprite(mario.Power.GetType()));
            main.Add(typeof(MarioRightJumpState), CreateStarMarioRightJumpSprite(mario.Power.GetType()));
            main.Add(typeof(MarioLeftAttackState), CreateStarMarioLeftShootFireSprite());
            main.Add(typeof(MarioRightAttackState), CreateStarMarioRightShootFireSprite());
            Type temp = mario.State.GetType();
            return main[temp];
        }

        public ISprite CreateStarMarioRightIdleSprite(Type curr)
        {
            Dictionary<Type, ISprite> RightIdle = new Dictionary<Type, ISprite>();
            RightIdle.Add(typeof(SmallMario), new StarMachine(spriteBatch, "SmallMarioRightIdle"));
            RightIdle.Add(typeof(BigMario), new StarMachine(spriteBatch, "BigMarioRightIdle"));
            RightIdle.Add(typeof(FireMario), new StarMachine(spriteBatch, "FireMarioRightIdle"));

            RightIdle.Add(typeof(Rosalina), new StarMachine(spriteBatch, "RosalinaRightIdle"));
            RightIdle.Add(typeof(GravityMario), new StarMachine(spriteBatch, "GravityRightIdle"));

            return RightIdle[curr];
        }

        public ISprite CreateStarMarioRightMovingSprite(Type curr)
        {
            Dictionary<Type, ISprite> RightMoving = new Dictionary<Type, ISprite>();
            RightMoving.Add(typeof(SmallMario), new StarMachine(spriteBatch, "SmallMarioRightMoving"));
            RightMoving.Add(typeof(BigMario), new StarMachine(spriteBatch, "BigMarioRightMoving"));
            RightMoving.Add(typeof(FireMario), new StarMachine(spriteBatch, "FireMarioRightMoving"));

            RightMoving.Add(typeof(GravityMario), new StarMachine(spriteBatch, "GravityRightMoving"));
            RightMoving.Add(typeof(Rosalina), new StarMachine(spriteBatch, "RosalinaRightMoving"));

            return RightMoving[curr];
        }

        public ISprite CreateStarMarioRightJumpSprite(Type curr)
        {
            Dictionary<Type, ISprite> RightJump = new Dictionary<Type, ISprite>();
            RightJump.Add(typeof(SmallMario), new StarMachine(spriteBatch, "SmallMarioRightJump"));
            RightJump.Add(typeof(BigMario), new StarMachine(spriteBatch, "BigMarioRightJump"));
            RightJump.Add(typeof(FireMario), new StarMachine(spriteBatch, "FireMarioRightJump"));

            RightJump.Add(typeof(GravityMario), new StarMachine(spriteBatch, "GravityRightJump"));
            RightJump.Add(typeof(Rosalina), new StarMachine(spriteBatch, "RosalinaRightJump"));

            return RightJump[curr];
        }

        public ISprite CreateStarMarioRightCrouchSprite(Type curr)
        {
            Dictionary<Type, ISprite> RightCrouch = new Dictionary<Type, ISprite>();
            RightCrouch.Add(typeof(BigMario), new StarMachine(spriteBatch, "BigMarioRightCrouch"));
            RightCrouch.Add(typeof(FireMario), new StarMachine(spriteBatch, "FireMarioRightCrouch"));
            //for compilation, never used
            RightCrouch.Add(typeof(SmallMario), new StarMachine(spriteBatch, "FireMarioRightCrouch"));

            RightCrouch.Add(typeof(Rosalina), new StarMachine(spriteBatch, "RosalinaRightCrouch"));
            RightCrouch.Add(typeof(GravityMario), new StarMachine(spriteBatch, "GravityRightCrouch"));

            return RightCrouch[curr];
        }

        public ISprite CreateStarMarioLeftIdleSprite(Type curr)
        {
            Dictionary<Type, ISprite> LeftIdle = new Dictionary<Type, ISprite>();
            LeftIdle.Add(typeof(SmallMario), new StarMachine(spriteBatch, "SmallMarioLeftIdle"));
            LeftIdle.Add(typeof(BigMario), new StarMachine(spriteBatch, "BigMarioLeftIdle"));
            LeftIdle.Add(typeof(FireMario), new StarMachine(spriteBatch, "FireMarioLeftIdle"));

            LeftIdle.Add(typeof(Rosalina), new StarMachine(spriteBatch, "RosalinaLeftIdle"));
            LeftIdle.Add(typeof(GravityMario), new StarMachine(spriteBatch, "GravityLeftIdle"));

            return LeftIdle[curr];
        }

        public ISprite CreateStarMarioLeftMovingSprite(Type curr)
        {
            Dictionary<Type, ISprite> LeftMoving = new Dictionary<Type, ISprite>();
            LeftMoving.Add(typeof(SmallMario), new StarMachine(spriteBatch, "SmallMarioLeftMoving"));
            LeftMoving.Add(typeof(BigMario), new StarMachine(spriteBatch, "BigMarioLeftMoving"));
            LeftMoving.Add(typeof(FireMario), new StarMachine(spriteBatch, "FireMarioLeftMoving"));

            LeftMoving.Add(typeof(GravityMario), new StarMachine(spriteBatch, "GravityLeftMoving"));
            LeftMoving.Add(typeof(Rosalina), new StarMachine(spriteBatch, "RosalinaLeftMoving"));

            return LeftMoving[curr];
        }

        public ISprite CreateStarMarioLeftJumpSprite(Type curr)
        {
            Dictionary<Type, ISprite> LeftJump = new Dictionary<Type, ISprite>();
            LeftJump.Add(typeof(SmallMario), new StarMachine(spriteBatch, "SmallMarioLeftJump"));
            LeftJump.Add(typeof(BigMario), new StarMachine(spriteBatch, "BigMarioLeftJump"));
            LeftJump.Add(typeof(FireMario), new StarMachine(spriteBatch, "FireMarioLeftJump"));

            LeftJump.Add(typeof(GravityMario), new StarMachine(spriteBatch, "GravityLeftJump"));
            LeftJump.Add(typeof(Rosalina), new StarMachine(spriteBatch, "RosalinaLeftJump"));

            return LeftJump[curr];
        }

        public ISprite CreateStarMarioLeftCrouchSprite(Type curr)
        {
            Dictionary<Type, ISprite> LeftCrouch = new Dictionary<Type, ISprite>();
            LeftCrouch.Add(typeof(BigMario), new StarMachine(spriteBatch, "BigMarioLeftCrouch"));
            LeftCrouch.Add(typeof(FireMario), new StarMachine(spriteBatch, "FireMarioLeftCrouch"));
            //for compilation, never used
            LeftCrouch.Add(typeof(SmallMario), new SpriteMachine(spriteBatch, "FireMarioLeftCrouch"));

            LeftCrouch.Add(typeof(Rosalina), new StarMachine(spriteBatch, "RosalinaLeftCrouch"));
            LeftCrouch.Add(typeof(GravityMario), new StarMachine(spriteBatch, "GravityLeftCrouch"));

            return LeftCrouch[curr];
        }

        public ISprite CreateStarMarioLeftShootFireSprite()
        {
            return new StarMachine(spriteBatch, "FireMarioLeftShootFire");
        }

        public ISprite CreateStarMarioRightShootFireSprite()
        {
            return new StarMachine(spriteBatch, "FireMarioRightShootFire");
        }

        public ISprite CreateDeadMarioSprite()
        {
            return new SpriteMachine(spriteBatch, "DeadMario");
        }

        public ISprite CreateBrickBlockSprite()
        {
            return new SpriteMachine(spriteBatch, "BrickBlock");
        }

        public ISprite CreateEmptyBlockSprite()
        {
            return new SpriteMachine(spriteBatch, "EmptyBlock");
        }

        public ISprite CreateQuestionBlockSprite()
        {
            return new SpriteMachine(spriteBatch, "QuestionBlock");
        }

        public ISprite CreateUsedBlockSprite()
        {
            return new SpriteMachine(spriteBatch, "UsedBlock");
        }

        public ISprite CreateCloudSprite()
        {
            return new SpriteMachine(spriteBatch, "Cloud");
        }

        public ISprite CreateHillSprite()
        {
            return new SpriteMachine(spriteBatch, "Hill");
        }

        public ISprite CreateBushSprite()
        {
            return new SpriteMachine(spriteBatch, "Bush");
        }

        public ISprite CreatePipeSprite()
        {
            return new SpriteMachine(spriteBatch, "Pipe");
        }

        public ISprite CreateHalfPipeSprite()
        {
            return new SpriteMachine(spriteBatch, "HalfPipe");
        }

        public ISprite CreateSolidBlockSprite()
        {
            return new SpriteMachine(spriteBatch, "SolidBlock");
        }

        public ISprite CreateCrackedBlockSprite()
        {
            return new SpriteMachine(spriteBatch, "CrackedBlock");
        }

        public ISprite CreateFireBallSprite()
        {
            return new SpriteMachine(spriteBatch, "FireBall");
        }


        public ISprite CreateCastleSprite()
        {
            return new SpriteMachine(spriteBatch, "Castle");
        }

        public ISprite CreateFlagPoleSprite()
        {
            return new SpriteMachine(spriteBatch, "FlagPole");
        }

        public ISprite CreateFlagSprite()
        {
            return new SpriteMachine(spriteBatch, "Flag");
        }

        public ISprite CreateMarioLeftDescendFlagSprite(Type curr)
        {
            Dictionary<Type, ISprite> DescendFlag = new Dictionary<Type, ISprite>();
            DescendFlag.Add(typeof(SmallMario), new SpriteMachine(spriteBatch, "SmallMarioLeftDescendFlag"));
            DescendFlag.Add(typeof(BigMario), new SpriteMachine(spriteBatch, "BigMarioLeftDescendFlag"));
            DescendFlag.Add(typeof(FireMario), new SpriteMachine(spriteBatch, "FireMarioLeftDescendFlag"));
            DescendFlag.Add(typeof(Rosalina), new SpriteMachine(spriteBatch, "RosalinaLeftFlag"));
            DescendFlag.Add(typeof(GravityMario), new SpriteMachine(spriteBatch, "GravityLeftFlag"));

            return DescendFlag[curr];
        }

        public ISprite CreateMarioRightDescendFlagSprite(Type curr)
        {
            Dictionary<Type, ISprite> DescendFlag = new Dictionary<Type, ISprite>();
            DescendFlag.Add(typeof(SmallMario), new SpriteMachine(spriteBatch, "SmallMarioRightDescendFlag"));
            DescendFlag.Add(typeof(BigMario), new SpriteMachine(spriteBatch, "BigMarioRightDescendFlag"));
            DescendFlag.Add(typeof(FireMario), new SpriteMachine(spriteBatch, "FireMarioRightDescendFlag"));
            DescendFlag.Add(typeof(Rosalina), new SpriteMachine(spriteBatch, "RosalinaRightFlag"));
            DescendFlag.Add(typeof(GravityMario), new SpriteMachine(spriteBatch, "GravityRightFlag"));

            return DescendFlag[curr];
        }

        public ISprite CreateEnemyJumpSprite(IEnemy enemy)
        {
            if (enemy is Goomba)
            {
                return new SpriteMachine(spriteBatch, "BlueGoomba");
            }
            else
            {
                if (enemy.MovementState is EnemyLeftMovementState)
                {
                    return new SpriteMachine(spriteBatch, "RedKoopaMovingLeft");
                }
                else
                {
                    return new SpriteMachine(spriteBatch, "RedKoopaMovingRight");
                }
            }
        }

        public ISprite CreateEnemyBigSprite(IEnemy enemy)
        {
            if (enemy is Goomba)
            {
                return new SpriteMachine(spriteBatch, "BigGoomba");
            }
            else
            {
                if (enemy.MovementState is EnemyLeftMovementState)
                {
                    return new SpriteMachine(spriteBatch, "BigKoopaMovingLeft");
                }
                else
                {
                    return new SpriteMachine(spriteBatch, "BigKoopaMovingRight");
                }
            }
        }

        public ISprite CreateEnemyRegularSprite(IEnemy enemy)
        {
            if (enemy is Goomba)
            {
                return new SpriteMachine(spriteBatch, "Goomba");
            }
            else
            {
                if (enemy.MovementState is EnemyLeftMovementState)
                {
                    return new SpriteMachine(spriteBatch, "KoopaMovingLeft");
                }
                else
                {
                    return new SpriteMachine(spriteBatch, "KoopaMovingRight");
                }
            }
        }

        public ISprite CreateEnemyStarSprite(IEnemy enemy)
        {
            if (enemy is Goomba)
            {
                return new StarMachine(spriteBatch, "Goomba");
            }
            else
            {
                if (enemy.MovementState is EnemyLeftMovementState)
                {
                    return new StarMachine(spriteBatch, "KoopaMovingLeft");
                }
                else
                {
                    return new StarMachine(spriteBatch, "KoopaMovingRight");
                }
            }
        }

        public ISprite SwitchKoopaRight(IEnemyPowerState power)
        {
            if (power is JumpState)
            {
                return new SpriteMachine(spriteBatch, "RedKoopaMovingRight");
            }
            else if (power is RegularState)
            {
                return new SpriteMachine(spriteBatch, "KoopaMovingRight");
            }
            else if (power is StarState)
            {
                return new StarMachine(spriteBatch, "KoopaMovingRight");
            }
            else if (power is MushroomState)
            {
                return new SpriteMachine(spriteBatch, "BigKoopaMovingRight");
            }
            else
            {
                return new SpriteMachine(spriteBatch, "StompedKoopa");
            }
        }

        public ISprite SwitchKoopaLeft(IEnemyPowerState power)
        {
            if (power is JumpState)
            {
                return new SpriteMachine(spriteBatch, "RedKoopaMovingLeft");
            }
            else if (power is RegularState)
            {
                return new SpriteMachine(spriteBatch, "KoopaMovingLeft");
            }
            else if (power is StarState)
            {
                return new StarMachine(spriteBatch, "KoopaMovingLeft");
            }
            else if (power is MushroomState)
            {
                return new SpriteMachine(spriteBatch, "BigKoopaMovingLeft");
            }
            else
            {
                return new SpriteMachine(spriteBatch, "StompedKoopa");
            }
        }

        public ISprite CreateRegularEnemyDeadSprite(IEnemy enemy)
        {
            if (enemy is Goomba)
            {
                return new SpriteMachine(spriteBatch, "StompedGoomba");
            }
            else
            {
                return new SpriteMachine(spriteBatch, "StompedKoopa");
            }
        }

        public ISprite CreateJumpEnemyDeadSprite(IEnemy enemy)
        {
            if (enemy is Goomba)
            {
                return new SpriteMachine(spriteBatch, "BlueStompedGoomba");
            }
            else
            {
                return new SpriteMachine(spriteBatch, "RedStompedKoopa");
            }
        }



    }
}
