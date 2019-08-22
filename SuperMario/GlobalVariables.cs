/* Author : David Cordle
 * Updated : July 7th 2019
 * Version : 5.0
 * Description: Static data class
 * for universal variables.
 */
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SuperMario
{
    public static class GlobalVariables
    {
        private static int coinCount;
        private static int score;
        private static int deathTimer;
        private static int lives;
        private static int cameraXPos;
        private static int cameraYPos;
        private static int cameraHeight;
        private static int gameTime = 300;
        private static int flagDescendSpeed = 2;
        private static int blockBumpDistance = 8;
        private static int coinBrickBumpDistance = 2;
        private static int maxCoinBrickHits = 3;
        private static int enemyStompedOffset = 16;
        private static int immuneTimer = 40;
        private static int cameraWidth = 800;
        private static int blockSize = 32;
        private static int fireballXOffset = 36;
        private static int fireballYOffset = 40;
        private static int coinOffset = 8;
        private static int speedUpTime = 100;
        private static int fireballCount;

        //Hard Coded Values for display times.
        //Tested until aesthetically pleasing.
        private static int timeToDeathScreen = 75;
        private static int blackScreenMax = 100;

        private static bool paused;
        private static bool enablePause;
        private static bool enableDeathCount;
        private static bool showBlackScreen;
        private static bool reset;
        private static bool gameOver;
        private static bool flagDescend;
        private static bool enableKeyboard;
        private static bool endOfGame;
        private static bool flipGravity;

        private static Keys pauseKey;

        public static void InitializeVar()
        {
            coinCount = 0;
            score = 0;
            deathTimer = 0;
            lives = 99;
            fireballCount = 0;

            cameraXPos = 0;
            cameraYPos = 0;

            paused = false;
            pauseKey = Keys.P;

            enablePause = true;
            enableDeathCount = false;

            flagDescend = false;
            flipGravity = false;

            enableKeyboard = true;

            endOfGame = false;
    }

        public static void ResetVar()
        {
            score = 0;
            deathTimer = 0;

            cameraXPos = 0;
            cameraYPos = 0;

            gameTime = 300;
            fireballCount = 0;

            paused = false;
            enablePause = true;
            enableDeathCount = false;

            flagDescend = false;

            flipGravity = false;

            enableKeyboard = true;

            endOfGame = false;
        }

        public static int CoinCount
        {
            get
            {
                return coinCount;
            }

            set
            {
                coinCount = value;
                if(coinCount > 99)
                {
                    coinCount = 0;
                    lives++;
                }
            }
        }

        public static int Score
        {
            get
            {
                return score;
            }
            
            set
            {
                score = value;
            }
        }

        public static int DeathTimer
        {
            get
            {
                return deathTimer;
            }
            set
            {
                deathTimer = value;
            }
        }

        public static int CoinOffset
        {
            get
            {
                return coinOffset;
            }
        }

        public static int InitDeath
        {
            get
            {
                return timeToDeathScreen;
            }
        }

        public static int ScreenDuration
        {
            get
            {
                return blackScreenMax;
            }
        }

        public static int SpeedUpTime
        {
            get
            {
                return speedUpTime;
            }
        }

        public static int CameraXPos
        {
            get
            {
                return cameraXPos;
            }
            set
            {
                cameraXPos = value;
            }
        }

        public static int CameraYPos
        {
            get
            {
                return cameraYPos;
            }
            set
            {
                cameraYPos = value;
            }
        }

        public static int FireballXOffset 
        {
            get 
            {
                return fireballXOffset;
            }
        }

        public static int FireballYOffset 
        {
            get 
            {
                return fireballYOffset;
            }
        }

        public static int FireballCount
        {
            get
            {
                return fireballCount;
            }
            set
            {
                fireballCount = value;
            }
        }

        public static int ImmuneTimer
        {
            get
            {
                return immuneTimer;
            }
            set
            {
                immuneTimer = value;
            }
        }

        public static int BlockSize
        {
            get
            {
                return blockSize;
            }
        }

        public static int EnemyStompedOffset
        {
            get
            {
                return enemyStompedOffset;
            }
            set
            {
                enemyStompedOffset = value;
            }
        }

        public static int MaxCoinBrickHits
        {
            get
            {
                return maxCoinBrickHits;
            }
        }

        public static int CoinBrickBumpDistance
        {
            get
            {
                return coinBrickBumpDistance;
            }
        }

        public static int BlockBumpDistance
        {
            get
            {
                return blockBumpDistance;
            }
        }

        public static int FlagDescendSpeed
        {
            get
            {
                return flagDescendSpeed;
            }
        }

        public static int FirstPlayerLives
        {
            get
            {
                return lives;
            }
            set
            {
                lives = value;
            }
        }

        public static int CameraWidth
        {
            get
            {
                return cameraWidth;
            }
            set
            {
                cameraWidth = value;
            }
        }

        public static int CameraHeight
        {
            get
            {
                return cameraHeight;
            }
            set
            {
                cameraHeight = value;
            }
        }

        public static int GameTime
        {
            get
            {
                return gameTime;
            }
            set
            {
                gameTime = value;
            }
        }

        public static bool Paused
        {
            get
            {
                return paused;
            }
            set
            {
                paused = value;
            }
        }

        public static bool EnablePause
        {
            get
            {
                return enablePause;
            }
            set
            {
                enablePause = value;
            }
        }

        public static bool FlagDescend
        {
            get
            {
                return flagDescend;
            }
            set
            {
                flagDescend = value;
            }
        }

        public static bool EnableKeyboard
        {
            get
            {
                return enableKeyboard;
            }
            set
            {
                enableKeyboard = value;
            }
        }

        public static bool EnableDeathCount
        {
            get
            {
                return enableDeathCount;
            }
            set
            {
                enableDeathCount = value;
                if(enableDeathCount)
                {
                    FirstPlayerLives--;
                }
            }
        }

        public static bool ShowBlackScreen
        {
            get
            {
                return showBlackScreen;
            }
            set
            {
                showBlackScreen = value;
            }
        }
        public static bool Reset
        {
            get
            {
                return reset;
            }
            set
            {
                reset = value;
            }
        }

        public static bool GameOver
        {
            get
            {
                return gameOver;
            }
            set
            {
                gameOver = value;
            }
        }

        public static bool EndOfGame
        {
            get
            {
                return endOfGame;
            }
            set
            {
                endOfGame = value;
            }
        }
        public static bool FlipGravity
        {
            get
            {
                return flipGravity;
            }
            set
            {
                flipGravity = value;
            }
        }

        public static Keys PauseKey
        {
            get
            {
                return pauseKey;
            }
        }

        public static void ResetTimer()
        {
            gameTime = 300;
        }

        public static void EndGame()
        {
            if (gameTime > 0)
            {
                score += gameTime * 100;
            }
            gameTime = -1;
        }
    }
}
