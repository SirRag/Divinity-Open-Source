using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Divinity.Tiles.DarkMatter
{
    public class ShadowChunkTileBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            dustType = 12;
            soundType = 21;
            soundStyle = 2;
            mineResist = 4f;
            minPick = 100;
            AddMapEntry(new Color(255, 100, 100));
            drop = mod.ItemType("ShadowChunk");
        }
        public override bool CanExplode(int i, int j)
        {
            if (Main.tile[i, j].type == mod.TileType("ShadowChunkTileBlock"))
            {
                return false;
            }
            return false;
        }
    }
}