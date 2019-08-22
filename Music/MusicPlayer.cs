using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public static class MusicPlayer
    {
        private static Dictionary<string, Song> musicDictionary = new Dictionary<string, Song>();
        private static Dictionary<string, SoundEffect> soundEffect = new Dictionary<string, SoundEffect>();


        public static Song SongList(string name)
        {
            return musicDictionary[name];
        }

        public static SoundEffect EffectList(string name)
        {
            return soundEffect[name];
        }

        public static void PlaySong(string name)
        {
            MediaPlayer.Volume = 0.7f;
            MediaPlayer.Play(musicDictionary[name]);
            MediaPlayer.IsRepeating = true;
        }

        public static void LoadSound(ContentManager content)
        {
            //David
            soundEffect.Add("1-Up", content.Load<SoundEffect>("1-Up"));
            soundEffect.Add("blockbump", content.Load<SoundEffect>("blockbump"));
            soundEffect.Add("coin", content.Load<SoundEffect>("coin"));
            soundEffect.Add("fireball", content.Load<SoundEffect>("fireball"));
            soundEffect.Add("jumpsmall", content.Load<SoundEffect>("jumpsmall"));
            soundEffect.Add("superJump", content.Load<SoundEffect>("superJump"));
            soundEffect.Add("pause", content.Load<SoundEffect>("pause"));

            //Nathan
            soundEffect.Add("flagpole", content.Load<SoundEffect>("flagpole"));
            soundEffect.Add("pipe", content.Load<SoundEffect>("pipe"));
            soundEffect.Add("powerup", content.Load<SoundEffect>("powerup"));
            soundEffect.Add("powerupAppear", content.Load<SoundEffect>("powerupAppear"));
            soundEffect.Add("stomp", content.Load<SoundEffect>("stomp"));
            soundEffect.Add("victory", content.Load<SoundEffect>("victory"));
            soundEffect.Add("timewarming", content.Load<SoundEffect>("timewarming"));

            musicDictionary.Add("LoopTheme", content.Load<Song>("LoopTheme"));
            musicDictionary.Add("starman", content.Load<Song>("starman"));
            soundEffect.Add("mariodeath", content.Load<SoundEffect>("mariodeath"));
            
        }
    }
}
