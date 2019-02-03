using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Divinity.Tiles.DivineBiome
{
    public class DivineGrassTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
			TileID.Sets.Grass[Type] = true;
            AddMapEntry(new Color(250, 100, 100));
            Main.tileMerge[mod.TileType("DivineDirtTile")][Type] = true;
            Main.tileMerge[mod.TileType("DivineGrassTile")][Type] = true;
			drop = mod.ItemType("DivineDirt"); // What item drops after destorying the tile
        }
        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return mod.TileType("DivineTreeSeed");
        }
        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i + 1, j].type == (ushort)mod.TileType("DivineGrassTile"))
            {
                bool TileOnRight = true;
            } 
            else             
            {
                bool TileOnRight = false;
            }

            if (Main.tile[i - 1, j].type == (ushort)mod.TileType("DivineGrassTile"))
            {
                bool TileOnLeft = true;
            }
            else
            {
                bool TileOnLeft = false;
            }

            if (Main.tile[i, j - 1].type == (ushort)mod.TileType("DivineGrassTile"))
            {
                bool TileOnTop = true;
            }
            else
            {
                bool TileOnTop = false;
            }

        }
    }
}