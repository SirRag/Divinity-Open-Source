using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Glacial
{
    public class IceCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Ice Crystal");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 26;
            item.maxStack = 999;
            item.value = 10000;
            item.rare = 2;
        }
    }
}