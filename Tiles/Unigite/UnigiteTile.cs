using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Divinity.Tiles.Unigite
{
    public class UnigiteTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = false;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.addTile(Type);
            dustType = 81;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Unigite Crafter");
            AddMapEntry(new Color(200, 200, 200), name);
            adjTiles = new int[] { TileID.Anvils };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("UnigiteItem"));
        }
    }
}