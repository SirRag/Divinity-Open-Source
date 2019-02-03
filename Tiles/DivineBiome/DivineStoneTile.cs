using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Divinity.Tiles.DivineBiome
{
    public class DivineStoneTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[mod.TileType("DivineStoneTile")][Type] = true;
            dustType = 53;
            soundType = 0;
            soundStyle = 2;
            AddMapEntry(new Color(255, 100, 100));
            drop = mod.ItemType("DivineStone");
			 Main.tileMerge[mod.TileType("DivineDirtTile")][Type] = true;
        }
    }
}