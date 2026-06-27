using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bone_By_Bone
{
    public static class AudioSettings
    {
        public static bool MusicOn { get; private set; } = true;
        public static bool SoundOn { get; private set; } = true;

        public static void SetMusic(bool value) => MusicOn = value;
        public static void SetSound(bool value) => SoundOn = value;
    }
}
