using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Sanchezium
{
    public class SancheziumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gragor Bar");
        }
        public override void SetDefaults()
        {
            item.maxStack = 99;
            item.rare = 4;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SancheziumOre", 5);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}