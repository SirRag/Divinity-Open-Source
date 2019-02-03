using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Gilded
{
    public class GildedBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gilded Bar");
        }
        public override void SetDefaults()
        {
            item.maxStack = 99;
            item.rare = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GildedOre", 5);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}