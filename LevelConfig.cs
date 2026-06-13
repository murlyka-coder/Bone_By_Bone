using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bone_By_Bone
{
    public class LevelConfig
    {

        public (int boneCount, Size boneSize) GetLevel(int level)
        {

            int boneCount = 0;
            Size boneSize = new Size(50, 40);

            if (level == 1)
            {
                boneCount = 8;
                boneSize = new Size(60, 40);
            }
            else if (level == 2)
            {
                boneCount = 12;
                boneSize = new Size(45, 35);
            }
            else if (level == 3)
            {
                boneCount = 21;
                boneSize = new Size(30, 25);
            }

            return (boneCount, boneSize);
        }

        public (int timeFor3Stars, int timeFor2Stars) GetStarThresholds(int level)
        {
            int timeFor3Stars = level == 1 ? 15 : (level == 2 ? 10 : 6);
            int timeFor2Stars = level == 1 ? 30 : (level == 2 ? 20 : 12);
            return (timeFor3Stars, timeFor2Stars);
        }
    }
}