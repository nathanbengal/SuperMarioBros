/* Authors: David Cordle, Nathan Bangal, Michael Troller
 * Version: 2.1
 * Description:Main Game Class
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections;
[assembly: CLSCompliant(true)]
//placeholder to create sprint4final branch

namespace SuperMario
{
    
    public class MarioGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardController controller;
        private Level level;
        private Queue levelHolder;
        private Camera camera;
        private Queue cameraHolder;
        private CameraManager view;
        private Queue viewHolder;
        private SpriteFont mainFont;

        public MarioGame()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth=800;
            GlobalVariables.CameraWidth = graphics.PreferredBackBufferWidth;
            graphics.PreferredBackBufferHeight=480;
            GlobalVariables.CameraHeight = graphics.PreferredBackBufferHeight;


            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            mainFont = Content.Load<SpriteFont>("MainFont");

            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.SpriteBatch = spriteBatch;
            SpriteMachine.LoadTextures(Content);

            levelHolder = new Queue();
            viewHolder = new Queue();
            cameraHolder = new Queue();
          
            level = new Level();
            level.LoadLevelContent("Underworld.xml", this);
            levelHolder.Enqueue(level);
            camera = new Camera(spriteBatch, mainFont);
            cameraHolder.Enqueue(camera);
            view = new CameraManager((Mario)level.Player, camera);
            viewHolder.Enqueue(view);
            level = new Level();
            level.LoadLevelContent("UnderworldTwo.xml", this);
            levelHolder.Enqueue(level);
            camera = new Camera(spriteBatch, mainFont);
            cameraHolder.Enqueue(camera);
            view = new CameraManager((Mario)level.Player, camera);
            viewHolder.Enqueue(view);
            level = new Level();
            level.LoadLevelContent("UnderworldThree.xml", this);
            levelHolder.Enqueue(level);
            camera = new Camera(spriteBatch, mainFont);
            cameraHolder.Enqueue(camera);
            view = new CameraManager((Mario)level.Player, camera);
            viewHolder.Enqueue(view);

            controller = new KeyboardController();
            GlobalVariables.InitializeVar();

            level = new Level();
            level.LoadLevelContent("Overworld.xml", this);
            level.SetStaticPlayer();
            levelHolder.Enqueue(level);
            camera = new Camera(spriteBatch, mainFont);
            cameraHolder.Enqueue(camera);
            view = new CameraManager((Mario)level.Player, camera);
            viewHolder.Enqueue(view);
            controller.InitWASD(this, level);
            base.Initialize();

        }
        
        protected override void LoadContent()
        {
            MusicPlayer.LoadSound(Content);
            MusicPlayer.PlaySong("LoopTheme");
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GlobalVariables.EnableKeyboard)
            {
                controller.Update();
            }
            if (GlobalVariables.Reset)
            {
                GlobalVariables.Reset = false;
                ResetLevel();
            }
            else if (!GlobalVariables.Paused && !GlobalVariables.GameOver)
            {
                level.Update();

                view.Update();
                base.Update(gameTime);
            }
            if (GlobalVariables.FlagDescend)
            {
                GlobalVariables.EndGame();
            }
            if (GlobalVariables.EndOfGame)
                MediaPlayer.Stop();
        }
  
        protected override void Draw(GameTime gameTime)
        {
            camera.Begin();
            if (GlobalVariables.GameOver)
            {
                GraphicsDevice.Clear(Color.TransparentBlack);
                camera.DrawText();
            }
            else if (GlobalVariables.ShowBlackScreen)
            {
                GraphicsDevice.Clear(Color.Black);
                camera.DrawText();
            }
            else
            {
                Nullable<Matrix> Translation = Matrix.CreateTranslation(60, 0, 0);
                GraphicsDevice.Clear(Color.CornflowerBlue);
                //spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Translation);
                level.Draw();
                camera.DrawText();
                base.Draw(gameTime);
            }
            camera.End();
        }

        public void ResetLevel()
        {
            levelHolder.Clear();
            cameraHolder.Clear();
            viewHolder.Clear();

            level = new Level();
            level.LoadLevelContent("Underworld.xml", this);
            levelHolder.Enqueue(level);
            camera = new Camera(spriteBatch, mainFont);
            cameraHolder.Enqueue(camera);
            view = new CameraManager((Mario)level.Player, camera);
            viewHolder.Enqueue(view);
            level = new Level();
            level.LoadLevelContent("UnderworldTwo.xml", this);
            levelHolder.Enqueue(level);
            camera = new Camera(spriteBatch, mainFont);
            cameraHolder.Enqueue(camera);
            view = new CameraManager((Mario)level.Player, camera);
            viewHolder.Enqueue(view);
            level = new Level();
            level.LoadLevelContent("UnderworldThree.xml", this);
            levelHolder.Enqueue(level);
            camera = new Camera(spriteBatch, mainFont);
            cameraHolder.Enqueue(camera);
            view = new CameraManager((Mario)level.Player, camera);
            viewHolder.Enqueue(view);

            level = new Level();
            level.LoadLevelContent("Overworld.xml", this);
            level.SetStaticPlayer();
            levelHolder.Enqueue(level);
            camera = new Camera(spriteBatch, mainFont);
            cameraHolder.Enqueue(camera);
            view = new CameraManager((Mario)level.Player, camera);
            viewHolder.Enqueue(view);

            controller.ClearKeyBindings();
            controller.InitWASD(this, level);
            GlobalVariables.ResetVar();

            MusicPlayer.PlaySong("LoopTheme");
        }

        public void SwapLevel()
        {
            Level swapLevel = level;
            level = (Level)levelHolder.Dequeue();
            levelHolder.Enqueue(swapLevel);

            Camera swapCamera = camera;
            camera = (Camera)cameraHolder.Dequeue();
            cameraHolder.Enqueue(swapCamera);

            CameraManager swapView = view;
            view = (CameraManager)viewHolder.Dequeue();
            viewHolder.Enqueue(swapView);

            controller.ClearKeyBindings();
            controller.InitWASD(this, level);
            level.SetStaticPlayer();
        }
    }
}
