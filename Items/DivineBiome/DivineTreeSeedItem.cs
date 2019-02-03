using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.DivineBiome
{
    public class DivineTreeSeedItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Tree Seed");
            Tooltip.SetDefault("Only placeable on Divine dirt with grass.");
        }
        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.useTurn = true;
            item.useStyle = 1;
            item.useAnimation = 15;
            item.useTime = 10;
            item.maxStack = 99;
            item.consumable = true;
            item.placeStyle = 0;
            item.width = 12;
            item.height = 14;
            item.value = 80;
            item.createTile = mod.TileType<Tiles.DivineBiome.DivineTreeSeed>();
        }
    }
}