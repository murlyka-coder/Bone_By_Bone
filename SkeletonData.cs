using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bone_By_Bone
{
    public class BoneDefinition
    {
        public string Id;
        public string ImageKey;
        public string GameImageKey;  // добавь сюда
        public Size BoneSize;
        public Point SlotPosition;
        public List<string> Neighbors;
    }

    public class SkeletonDefinition
    {
        public string Id;
        public string StartBoneId;
        public List<BoneDefinition> Bones;

        public BoneDefinition GetBone(string id)
        {
            return Bones.Find(b => b.Id == id);
        }
    }

    public static class SkeletonLibrary
    {
        public static SkeletonDefinition GetSkeleton(int level)
        {
            switch (level)
            {
                case 1: return Dinosaur();
                case 2: return Human();
                case 3: return Cat();
                default: return Dinosaur();
            }
        }



        private static SkeletonDefinition Dinosaur()
        {
            return new SkeletonDefinition
            {
                Id = "dinosaur",
                StartBoneId = "head",
                Bones = new List<BoneDefinition>
        {
            new BoneDefinition { Id = "head", ImageKey = "dino_head", GameImageKey = "dino_head_game", BoneSize = new Size(1200, 700), SlotPosition = new Point(0, 0), Neighbors = new List<string> { "sheia" } },
            new BoneDefinition { Id = "sheia", ImageKey = "dino_sheia", GameImageKey = "dino_sheia_game", BoneSize = new Size(1200, 700), SlotPosition = new Point(0, 0), Neighbors = new List<string> { "arms", "ribs" } },
            new BoneDefinition { Id = "arms", ImageKey = "dino_arms", GameImageKey = "dino_arms_game", BoneSize = new Size(1200, 700), SlotPosition = new Point(0, 0), Neighbors = new List<string> { "ribs" } },
            new BoneDefinition { Id = "ribs", ImageKey = "dino_ribs", GameImageKey = "dino_ribs_game", BoneSize = new Size(1200, 700), SlotPosition = new Point(0, 0), Neighbors = new List<string> { "taz" } },
            new BoneDefinition { Id = "taz", ImageKey = "dino_taz", GameImageKey = "dino_taz_game", BoneSize = new Size(1200, 700), SlotPosition = new Point(0, 0), Neighbors = new List<string> { "leg_front", "leg_back", "tail" } },
            new BoneDefinition { Id = "leg_front", ImageKey = "dino_leg_front", GameImageKey = "dino_leg_front_game", BoneSize = new Size(1200, 700), SlotPosition = new Point(0, 0), Neighbors = new List<string> { } },
            new BoneDefinition { Id = "leg_back", ImageKey = "dino_leg_back", GameImageKey = "dino_leg_back_game", BoneSize = new Size(1200, 700), SlotPosition = new Point(0, 0), Neighbors = new List<string> { } },
            new BoneDefinition { Id = "tail", ImageKey = "dino_tail", GameImageKey = "dino_tail_game", BoneSize = new Size(1200, 700), SlotPosition = new Point(0, 0), Neighbors = new List<string> { } },
        }
            };
        }

        private static SkeletonDefinition Human()
        {
            return new SkeletonDefinition
            {
                Id = "human",
                StartBoneId = "skull",
                Bones = new List<BoneDefinition>
                {
                    new BoneDefinition { Id = "skull",    ImageKey = "dino_skull",    SlotPosition = new Point(50,  100), Neighbors = new List<string> { "neck" } },
                    new BoneDefinition { Id = "neck",     ImageKey = "dino_neck",     SlotPosition = new Point(180, 80),  Neighbors = new List<string> { "arms", "ribs" } },
                    new BoneDefinition { Id = "arms",     ImageKey = "dino_arms",     SlotPosition = new Point(300, 50),  Neighbors = new List<string> { "ribs" } },
                    new BoneDefinition { Id = "ribs",     ImageKey = "dino_ribs",     SlotPosition = new Point(420, 80),  Neighbors = new List<string> { "leg_back" } },
                    new BoneDefinition { Id = "leg_back", ImageKey = "dino_leg_back", SlotPosition = new Point(580, 70),  Neighbors = new List<string> { "tail" } },
                    new BoneDefinition { Id = "tail",     ImageKey = "dino_tail",     SlotPosition = new Point(730, 50),  Neighbors = new List<string> { } },
                }
            };
        }

        private static SkeletonDefinition Cat()
        {
            return new SkeletonDefinition
            {
                Id = "cat",
                StartBoneId = "skull",
                Bones = new List<BoneDefinition>
                {
                    new BoneDefinition { Id = "skull",        ImageKey = "cat_skull",        SlotPosition = new Point(180, 150), Neighbors = new List<string> { "neck" } },
                    new BoneDefinition { Id = "neck",         ImageKey = "cat_neck",         SlotPosition = new Point(370, 100), Neighbors = new List<string> { "shoulder_blade" } },
                    new BoneDefinition { Id = "shoulder_blade",ImageKey = "cat_shoulder",    SlotPosition = new Point(490, 80),  Neighbors = new List<string> { "ribs", "leg_front" } },
                    new BoneDefinition { Id = "ribs",         ImageKey = "cat_ribs",         SlotPosition = new Point(620, 150), Neighbors = new List<string> { "pelvis" } },
                    new BoneDefinition { Id = "leg_front",    ImageKey = "cat_leg_front",    SlotPosition = new Point(430, 300), Neighbors = new List<string> { "pelvis" } },
                    new BoneDefinition { Id = "pelvis",       ImageKey = "cat_pelvis",       SlotPosition = new Point(820, 120), Neighbors = new List<string> { "tail", "leg_back" } },
                    new BoneDefinition { Id = "tail",         ImageKey = "cat_tail",         SlotPosition = new Point(1000, 200),Neighbors = new List<string> { } },
                    new BoneDefinition { Id = "leg_back",     ImageKey = "cat_leg_back",     SlotPosition = new Point(800, 350), Neighbors = new List<string> { } },
                }
            };
        }
    }
}