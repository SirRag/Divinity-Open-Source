using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.DarkMatter
{
    public class ShadowChunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Chunk");
            Tooltip.SetDefault("Used to craft Dark Matter.");
        }
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.autoReuse = true;
            item.rare = 4;
            item.consumable = true;
            item.createTile = mod.TileType("ShadowChunkTileBlock");
        }
    }
}