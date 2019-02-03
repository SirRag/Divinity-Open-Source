using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Divinity.Items.DarkMatter
{
    public class DarkMatter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Matter");
			Tooltip.SetDefault("");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 5));
            ItemID.Sets.ItemIconPulse[item.type] = false;
            ItemID.Sets.ItemNoGravity[item.type] = false;
        }
        public override void SetDefaults()
        {
            item.maxStack = 99;
            item.rare = 4;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ShadowChunk", 5);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}