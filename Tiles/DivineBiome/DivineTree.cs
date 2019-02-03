using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Divinity.Tiles.DivineBiome
{
    public class DivineTree : ModTree
    {
        private Mod mod
        {
            get
            {
                return ModLoader.GetMod("Divinity");
            }
        }

        public override int CreateDust()
        {
            return 53;
        }

        public override int GrowthFXGore()
        {
            return mod.GetGoreSlot("Tiles/DivineBiome/DivineTreeFX");
        }

        public override int DropWood()
        {
            return mod.ItemType("DivineWood");
        }

        public override Texture2D GetTexture()
        {
            return mod.GetTexture("Tiles/DivineBiome/DivineTree");
        }

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
        {
            return mod.GetTexture("Tiles/DivineBiome/DivineTree_Branches");
        }

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            return mod.GetTexture("Tiles/DivineBiome/DivineTree_Tops");
        }
    }
}