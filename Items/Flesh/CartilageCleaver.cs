using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Flesh
{
	public class CartilageCleaver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cartilage Cleaver");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.damage = 42;
			item.melee = true;
			item.width = 48;
			item.height = 50;
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
            recipe.AddIngredient(null, "CrawlingFlesh", 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
