using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HF
{
    public static class Sounds
    {
        private static SoundManager Manager;

        public static void Initialize(SoundManager sm)
        {
            Manager = sm;
        }

        public static void PlaySound(PlayerSlot who,SoundClip sound)
        {
            Manager.PlaySound(who, Library.GetSound(sound));
        }
    }
}
