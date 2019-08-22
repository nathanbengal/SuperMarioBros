using System;
using System.Collections.Generic;
using System.Reflection;

namespace SuperMario
{
    class CollisionHandler
    {
        private Dictionary<CollisionObject, ConstructorInfo> collisionMatrix;
        private CollisionObject collisionInfo;
        private ConstructorInfo handlerInfo;
        private Type[] handlerParams;
        private Level level;
        private MarioGame game;

        public CollisionHandler(Level level, MarioGame game)
        {
            this.level = level;
            this.game = game;
            collisionMatrix = new Dictionary<CollisionObject, ConstructorInfo>();
            handlerParams = new Type[2];
            handlerParams[0] = typeof(CollisionObject);
            handlerParams[1] = typeof(Level);

            Type[] WarpParams = new Type[3];
            WarpParams[0] = typeof(CollisionObject);
            WarpParams[1] = typeof(Level);
            WarpParams[2] = typeof(MarioGame);

            //Mario and Blocks
            collisionInfo = new CollisionObject(typeof(CoinBlock), typeof(Mario));
            handlerInfo = typeof(MarioCoinBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(ItemBlock), typeof(Mario));
            handlerInfo = typeof(MarioItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(HiddenBlock), typeof(Mario));
            handlerInfo = typeof(MarioHiddenBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(BrickBlock), typeof(Mario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(UsedBlock), typeof(Mario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CrackedBlock), typeof(Mario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SolidBlock), typeof(Mario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CoinBrick), typeof(Mario));
            handlerInfo = typeof(MarioCoinBrickHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Pipe), typeof(Mario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(HalfPipe), typeof(Mario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarBrick), typeof(Mario));
            handlerInfo = typeof(MarioStarBrickHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(WarpPipe), typeof(Mario));
            handlerInfo = typeof(MarioWarpPipeHandler).GetConstructor(WarpParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);


            //Mario and Enemies
            collisionInfo = new CollisionObject(typeof(Mario), typeof(Goomba));
            handlerInfo = typeof(MarioEnemyHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Mario), typeof(Koopa));
            handlerInfo = typeof(MarioEnemyHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            //Mario and Items
            collisionInfo = new CollisionObject(typeof(Mario), typeof(Mushroom));
            handlerInfo = typeof(MarioMushroomHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(FireFlower), typeof(Mario));
            handlerInfo = typeof(MarioFireFlowerHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SuperCrown), typeof(Mario));
            handlerInfo = typeof(MarioSuperCrown).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Mario), typeof(GravityOrb));
            handlerInfo = typeof(MarioGravityOrb).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Mario), typeof(Star));
            handlerInfo = typeof(MarioStarHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Coin), typeof(Mario));
            handlerInfo = typeof(MarioCoinHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Mario), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(MarioExtraLifeMushroomHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            //StarMario and Blocks
            collisionInfo = new CollisionObject(typeof(CoinBlock), typeof(StarMario));
            handlerInfo = typeof(MarioCoinBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(ItemBlock), typeof(StarMario));
            handlerInfo = typeof(MarioItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(HiddenBlock), typeof(StarMario));
            handlerInfo = typeof(MarioHiddenBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(BrickBlock), typeof(StarMario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(UsedBlock), typeof(StarMario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CrackedBlock), typeof(StarMario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SolidBlock), typeof(StarMario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CoinBrick), typeof(StarMario));
            handlerInfo = typeof(MarioCoinBrickHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Pipe), typeof(StarMario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(HalfPipe), typeof(StarMario));
            handlerInfo = typeof(MarioBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarBrick), typeof(StarMario));
            handlerInfo = typeof(MarioStarBrickHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(WarpPipe), typeof(StarMario));
            handlerInfo = typeof(MarioWarpPipeHandler).GetConstructor(WarpParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);


            //StarMario and Enemies
            collisionInfo = new CollisionObject(typeof(StarMario), typeof(Goomba));
            handlerInfo = typeof(MarioEnemyHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarMario), typeof(Koopa));
            handlerInfo = typeof(MarioEnemyHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            //StarMario and Items
            collisionInfo = new CollisionObject(typeof(StarMario), typeof(Mushroom));
            handlerInfo = typeof(MarioMushroomHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(FireFlower), typeof(StarMario));
            handlerInfo = typeof(MarioFireFlowerHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarMario), typeof(Star));
            handlerInfo = typeof(MarioStarHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SuperCrown), typeof(StarMario));
            handlerInfo = typeof(MarioSuperCrown).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarMario), typeof(GravityOrb));
            handlerInfo = typeof(MarioGravityOrb).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);


            collisionInfo = new CollisionObject(typeof(Coin), typeof(StarMario));
            handlerInfo = typeof(MarioCoinHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarMario), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(MarioExtraLifeMushroomHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            //GoombaBlockHandlers
            collisionInfo = new CollisionObject(typeof(CoinBlock), typeof(Goomba));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(ItemBlock), typeof(Goomba));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(BrickBlock), typeof(Goomba));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(UsedBlock), typeof(Goomba));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CrackedBlock), typeof(Goomba));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SolidBlock), typeof(Goomba));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CoinBrick), typeof(Goomba));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Pipe), typeof(Goomba));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(HalfPipe), typeof(Goomba));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarBrick), typeof(Goomba));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(WarpPipe), typeof(Goomba));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            //KoopaBlockhandler
            collisionInfo = new CollisionObject(typeof(CoinBlock), typeof(Koopa));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(ItemBlock), typeof(Koopa));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(BrickBlock), typeof(Koopa));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(UsedBlock), typeof(Koopa));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CrackedBlock), typeof(Koopa));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SolidBlock), typeof(Koopa));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CoinBrick), typeof(Koopa));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Pipe), typeof(Koopa));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(HalfPipe), typeof(Koopa));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarBrick), typeof(Koopa));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(WarpPipe), typeof(Koopa));
            handlerInfo = typeof(EnemyBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            //StarBlockHandlers
            collisionInfo = new CollisionObject(typeof(CoinBlock), typeof(Star));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(ItemBlock), typeof(Star));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(BrickBlock), typeof(Star));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(UsedBlock), typeof(Star));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CrackedBlock), typeof(Star));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SolidBlock), typeof(Star));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CoinBrick), typeof(Star));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Pipe), typeof(Star));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(HalfPipe), typeof(Star));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(WarpPipe), typeof(Star));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);



            //MushroomBlockHandlers
            collisionInfo = new CollisionObject(typeof(CoinBlock), typeof(Mushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(ItemBlock), typeof(Mushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(BrickBlock), typeof(Mushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(UsedBlock), typeof(Mushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CrackedBlock), typeof(Mushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SolidBlock), typeof(Mushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CoinBrick), typeof(Mushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Pipe), typeof(Mushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(HalfPipe), typeof(Mushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarBrick), typeof(Mushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(WarpPipe), typeof(Mushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Gravity Orb Collisions
            collisionInfo = new CollisionObject(typeof(CoinBlock), typeof(GravityOrb));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(ItemBlock), typeof(GravityOrb));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(BrickBlock), typeof(GravityOrb));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(UsedBlock), typeof(GravityOrb));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CrackedBlock), typeof(GravityOrb));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SolidBlock), typeof(GravityOrb));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CoinBrick), typeof(GravityOrb));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Pipe), typeof(GravityOrb));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(HalfPipe), typeof(GravityOrb));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarBrick), typeof(GravityOrb));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(WarpPipe), typeof(GravityOrb));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //ExtraLifeMushroom
            collisionInfo = new CollisionObject(typeof(CoinBlock), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(ItemBlock), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(BrickBlock), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(UsedBlock), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CrackedBlock), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SolidBlock), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CoinBrick), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Pipe), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(HalfPipe), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarBrick), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(WarpPipe), typeof(ExtraLifeMushroom));
            handlerInfo = typeof(ItemBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            //EnemyEnemyHandler
            collisionInfo = new CollisionObject(typeof(Goomba), typeof(Koopa));
            handlerInfo = typeof(EnemyEnemyHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Koopa), typeof(Goomba));
            handlerInfo = typeof(EnemyEnemyHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Goomba), typeof(Goomba));
            handlerInfo = typeof(EnemyEnemyHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Koopa), typeof(Koopa));
            handlerInfo = typeof(EnemyEnemyHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            //FireBallHandlers
            collisionInfo = new CollisionObject(typeof(CoinBlock), typeof(FireBall));
            handlerInfo = typeof(FireballBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(ItemBlock), typeof(FireBall));
            handlerInfo = typeof(FireballBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(BrickBlock), typeof(FireBall));
            handlerInfo = typeof(FireballBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(UsedBlock), typeof(FireBall));
            handlerInfo = typeof(FireballBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CrackedBlock), typeof(FireBall));
            handlerInfo = typeof(FireballBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SolidBlock), typeof(FireBall));
            handlerInfo = typeof(FireballBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(CoinBrick), typeof(FireBall));
            handlerInfo = typeof(FireballBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Pipe), typeof(FireBall));
            handlerInfo = typeof(FireballBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(HalfPipe), typeof(FireBall));
            handlerInfo = typeof(FireballBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(StarBrick), typeof(FireBall));
            handlerInfo = typeof(FireballBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Koopa), typeof(FireBall));
            handlerInfo = typeof(FireballEnemyHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Goomba), typeof(FireBall));
            handlerInfo = typeof(FireballEnemyHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(WarpPipe), typeof(FireBall));
            handlerInfo = typeof(FireballBlockHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            //Flagpole

            collisionInfo = new CollisionObject(typeof(FlagPole), typeof(Mario));
            handlerInfo = typeof(MarioFlagPoleHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            //Flag

            collisionInfo = new CollisionObject(typeof(Flag), typeof(Mario));
            handlerInfo = typeof(MarioFlagHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            // Enemies and items

            collisionInfo = new CollisionObject(typeof(FireFlower), typeof(Goomba));
            handlerInfo = typeof(EnemyMushroomHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Mushroom), typeof(Goomba));
            handlerInfo = typeof(EnemyMushroomHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SuperCrown), typeof(Goomba));
            handlerInfo = typeof(EnemyJumpHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(GravityOrb), typeof(Goomba));
            handlerInfo = typeof(EnemyJumpHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Goomba), typeof(SuperCrown));
            handlerInfo = typeof(EnemyJumpHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Goomba), typeof(GravityOrb));
            handlerInfo = typeof(EnemyJumpHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Star), typeof(Goomba));
            handlerInfo = typeof(EnemyStarHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(FireFlower), typeof(Koopa));
            handlerInfo = typeof(EnemyJumpHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Mushroom), typeof(Koopa));
            handlerInfo = typeof(EnemyMushroomHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Star), typeof(Koopa));
            handlerInfo = typeof(EnemyStarHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(SuperCrown), typeof(Koopa));
            handlerInfo = typeof(EnemyJumpHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(GravityOrb), typeof(Koopa));
            handlerInfo = typeof(EnemyJumpHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Koopa), typeof(SuperCrown));
            handlerInfo = typeof(EnemyJumpHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Koopa), typeof(GravityOrb));
            handlerInfo = typeof(EnemyJumpHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            //Enemies and items backwards
            collisionInfo = new CollisionObject(typeof(Goomba), typeof(FireFlower));
            handlerInfo = typeof(EnemyJumpHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Goomba), typeof(Mushroom));
            handlerInfo = typeof(EnemyMushroomHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Goomba), typeof(Star));
            handlerInfo = typeof(EnemyStarHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Koopa), typeof(FireFlower));
            handlerInfo = typeof(EnemyJumpHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Koopa), typeof(Mushroom));
            handlerInfo = typeof(EnemyMushroomHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);

            collisionInfo = new CollisionObject(typeof(Koopa), typeof(Star));
            handlerInfo = typeof(EnemyStarHandler).GetConstructor(handlerParams);
            collisionMatrix.Add(collisionInfo, handlerInfo);



        }

        public void Handle(List<CollisionObject> collisionList)
        {
            foreach(CollisionObject Info in collisionList)
            {
                if (collisionMatrix.ContainsKey(Info))
                {
                    Object[] paramaters = new object[2];
                    paramaters[0] = Info;
                    paramaters[1] = level;
                    if (Info.LeftSlot is WarpPipe && (Info.RightSlot is Mario||Info.RightSlot is StarMario))
                    {
                        paramaters = new object[3];
                        paramaters[0] = Info;
                        paramaters[1] = level;
                        paramaters[2] = game;
                    }
                    ICollisionHandler Handler = (ICollisionHandler)collisionMatrix[Info].Invoke(paramaters);
                    Handler.Execute();
                }
            }
        }
    }
}
