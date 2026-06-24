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
        public Point SlotPosition;
        public Size BoneSize;          // добавь это
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
                StartBoneId = "skull",
                Bones = new List<BoneDefinition>
        {
                    new BoneDefinition { Id = "skull",    ImageKey = "dino_skull",    BoneSize = new Size(200, 200), SlotPosition = new Point(30,  80),  Neighbors = new List<string> { "neck" } },
                    new BoneDefinition { Id = "neck",     ImageKey = "dino_neck",     BoneSize = new Size(180, 180), SlotPosition = new Point(220, 60),  Neighbors = new List<string> { "arms", "ribs" } },
                    new BoneDefinition { Id = "arms",     ImageKey = "dino_arms",     BoneSize = new Size(150, 200), SlotPosition = new Point(340, 200), Neighbors = new List<string> { "ribs" } },
                    new BoneDefinition { Id = "ribs",     ImageKey = "dino_ribs",     BoneSize = new Size(250, 280), SlotPosition = new Point(360, 30),  Neighbors = new List<string> { "leg_back" } },
                    new BoneDefinition { Id = "leg_back", ImageKey = "dino_leg_back", BoneSize = new Size(200, 320), SlotPosition = new Point(530, 80), Neighbors = new List<string> { "tail" } },
                    new BoneDefinition { Id = "tail",     ImageKey = "dino_tail",     BoneSize = new Size(420, 160), SlotPosition = new Point(680, 50),  Neighbors = new List<string> { } },
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