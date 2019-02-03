using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Gilded
{
	public class GildedSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gilded Sword");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.damage = 17;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 19;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		
		  public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GildedBar", 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
