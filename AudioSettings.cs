using System;
using System.Media; // Добавляем пространство имен для SoundPlayer

namespace Bone_By_Bone
{
    public static class AudioSettings
    {
        public static bool MusicOn { get; private set; } = true;
        public static bool SoundOn { get; private set; } = true;

        // Создаем плеер
        private static SoundPlayer bgMusicPlayer;

        // Метод для первоначальной загрузки музыки
        public static void InitMusic()
        {
            try
            {
                // Загружаем музыку из ресурсов. 
                // Замени "background_music" на точное имя твоего файла в ресурсах
                bgMusicPlayer = new SoundPlayer(Properties.Resources.background_music);

                if (MusicOn)
                {
                    bgMusicPlayer.PlayLooping(); // Играть по кругу
                }
            }
            catch (Exception ex)
            {
                // Если файла нет, музыка просто не будет играть, игра не вылетит
                Console.WriteLine("Ошибка загрузки музыки: " + ex.Message);
            }
        }

        public static void SetMusic(bool value)
        {
            MusicOn = value;

            if (bgMusicPlayer != null)
            {
                if (MusicOn)
                {
                    bgMusicPlayer.PlayLooping();
                }
                else
                {
                    bgMusicPlayer.Stop();
                }
            }
        }

        public static void SetSound(bool value)
        {
            SoundOn = value;
            // Здесь в будущем можно будет глушить/включать короткие звуки (например, клики или звук установки кости)
        }
    }
}