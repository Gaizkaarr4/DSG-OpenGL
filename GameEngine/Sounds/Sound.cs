using System;
using System.Collections.Generic;
using System.Text;
using NetCoreAudio;

namespace GameEngine.Sounds
{
    public class Sound
    {
        private static Player Player = new Player();
        private string Filename;
        public Sound(string filename)
        {
            Filename = filename;
        }

        public void Play()
        {
            Player.Play(Filename);
        }

        public void Stop()
        {
            Player.Stop();
        }
    }
}
