using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Unigite
{
	public class UnigiteItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unigite Crafter");
			Tooltip.SetDefault("Used to smelt Divinity Ores.");
		}
		public override void SetDefaults()
		{
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.rare = 5;
			item.consumable = true;
			item.createTile = mod.TileType("UnigiteTile");
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Chassis", 1);
            recipe.AddIngredient(null, "PowerStabilizer", 1);
            recipe.AddIngredient(null, "ControlModule", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}