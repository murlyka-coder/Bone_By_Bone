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
                case 2: return Cat();
                case 3: return Human();
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
                StartBoneId = "head",
                Bones = new List<BoneDefinition>
                {
                    new BoneDefinition { Id = "head",       ImageKey = "men_head",        GameImageKey = "men_head_game",        BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "sheya" } },
                    new BoneDefinition { Id = "sheya",      ImageKey = "men_sheya",       GameImageKey = "men_sheya_game",       BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "lopat1", "lopat2", "cluchis1", "cluchis2", "ribs" } },
                    new BoneDefinition { Id = "lopat1",     ImageKey = "men_lopat1",      GameImageKey = "men_lopat1_game",      BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "plesho1" } },
                    new BoneDefinition { Id = "lopat2",     ImageKey = "men_lopat2",      GameImageKey = "men_lopat2_game",      BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "plesho2" } },
                    new BoneDefinition { Id = "cluchis1",   ImageKey = "men_cluchis1",    GameImageKey = "men_cluchis1_game",    BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "plesho1" } },
                    new BoneDefinition { Id = "cluchis2",   ImageKey = "men_cluchis2",    GameImageKey = "men_cluchis2_game",    BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "plesho2" } },
                    new BoneDefinition { Id = "plesho1",    ImageKey = "men_plesho1",     GameImageKey = "men_plesho1_game",     BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "predplesho1" } },
                    new BoneDefinition { Id = "plesho2",    ImageKey = "men_plesho2",     GameImageKey = "men_plesho2_game",     BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "predplesho2" } },
                    new BoneDefinition { Id = "predplesho1",ImageKey = "men_predplesho1", GameImageKey = "men_predplesho1_game", BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "ruka1" } },
                    new BoneDefinition { Id = "predplesho2",ImageKey = "men_predplesho2", GameImageKey = "men_predplesho2_game", BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "ruka2" } },
                    new BoneDefinition { Id = "ruka1",      ImageKey = "men_ruka1",       GameImageKey = "men_ruka1_game",       BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { } },
                    new BoneDefinition { Id = "ruka2",      ImageKey = "men_ruka2",       GameImageKey = "men_ruka2_game",       BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { } },
                    new BoneDefinition { Id = "ribs",       ImageKey = "men_ribs",        GameImageKey = "men_ribs_game",        BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "spina" } },
                    new BoneDefinition { Id = "spina",      ImageKey = "men_spina",       GameImageKey = "men_spina_game",       BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "taz" } },
                    new BoneDefinition { Id = "taz",        ImageKey = "men_taz",         GameImageKey = "men_taz_game",         BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "bedro1", "bedro2" } },
                    new BoneDefinition { Id = "bedro1",     ImageKey = "men_bedro1",      GameImageKey = "men_bedro1_game",      BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "golen1" } },
                    new BoneDefinition { Id = "bedro2",     ImageKey = "men_bedro2",      GameImageKey = "men_bedro2_game",      BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "golen2" } },
                    new BoneDefinition { Id = "golen1",     ImageKey = "men_golen1",      GameImageKey = "men_golen1_game",      BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "stopa1" } },
                    new BoneDefinition { Id = "golen2",     ImageKey = "men_golen2",      GameImageKey = "men_golen2_game",      BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "stopa2" } },
                    new BoneDefinition { Id = "stopa1",     ImageKey = "men_stopa1",      GameImageKey = "men_stopa1_game",      BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { } },
                    new BoneDefinition { Id = "stopa2",     ImageKey = "men_stopa2",      GameImageKey = "men_stopa2_game",      BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { } },
                }
            };
        }

        private static SkeletonDefinition Cat()
        {
            return new SkeletonDefinition
            {
                Id = "cat",
                StartBoneId = "head",
                Bones = new List<BoneDefinition>
                {
                    new BoneDefinition { Id = "head",  ImageKey = "cat_head",  GameImageKey = "cat_head_game",  BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "sheya" } },
                    new BoneDefinition { Id = "sheya", ImageKey = "cat_sheya", GameImageKey = "cat_sheya_game", BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "noga1", "ribs" } },
                    new BoneDefinition { Id = "noga1", ImageKey = "cat_noga1", GameImageKey = "cat_noga1_game", BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "noga2" } },
                    new BoneDefinition { Id = "noga2", ImageKey = "cat_noga2", GameImageKey = "cat_noga2_game", BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "ribs" } },
                    new BoneDefinition { Id = "ribs",  ImageKey = "cat_ribs",  GameImageKey = "cat_ribs_game",  BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "spina" } },
                    new BoneDefinition { Id = "spina", ImageKey = "cat_spina", GameImageKey = "cat_spina_game", BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "noga3", "tail" } },
                    new BoneDefinition { Id = "noga3", ImageKey = "cat_noga3", GameImageKey = "cat_noga3_game", BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { "noga4" } },
                    new BoneDefinition { Id = "noga4", ImageKey = "cat_noga4", GameImageKey = "cat_noga4_game", BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { } },
                    new BoneDefinition { Id = "tail",  ImageKey = "cat_tail",  GameImageKey = "cat_tail_game",  BoneSize = new Size(1200,700), SlotPosition = new Point(0,0), Neighbors = new List<string> { } },
                }
            };
        }
    }
}