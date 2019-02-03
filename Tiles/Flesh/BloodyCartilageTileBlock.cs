using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Divinity.Tiles.Flesh
{
    public class BloodyCartilageTileBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            dustType = 12;
            soundType = 21;
            soundStyle = 2;
            mineResist = 4f;
            minPick = 100;
            AddMapEntry(new Color(255, 100, 100));
            drop = mod.ItemType("BloodyCartilage");
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.7f;
            g = 0.1f;
            b = 0.1f;
        }
        public override bool CanExplode(int i, int j)
        {
            if (Main.tile[i, j].type == mod.TileType("BloodyCartilageTileBlock"))
            {
                return false;
            }
            return false;
        }
    }
}