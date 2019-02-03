using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Flesh
{
    public class BloodyCartilage : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Cartilage");
            Tooltip.SetDefault("");
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
            item.createTile = mod.TileType("BloodyCartilageTileBlock");
        }
    }
}