using System.Media;

namespace World_s_Hardest_Game
{
    public class AudioManager
    {
        // class for playing the audio

        public SoundPlayer theme, button, death, coin, level;

        public AudioManager()
        {
            theme = new SoundPlayer(Properties.Resources.theme);
            button = new SoundPlayer(Properties.Resources.button);
            death = new SoundPlayer(Properties.Resources.death);
            coin = new SoundPlayer(Properties.Resources.coin);
            level = new SoundPlayer(Properties.Resources.level);
        }
    }
}
