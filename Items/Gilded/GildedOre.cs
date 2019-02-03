using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Gilded
{
    public class GildedOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gilded Ore");
        }
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.autoReuse = true;
            item.rare = 1;
            item.consumable = true;
            item.createTile = mod.TileType("GildedOreTile");
            item.rare = 5;
        }
    }
}