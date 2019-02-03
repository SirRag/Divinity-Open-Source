using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Divinity.Items.Gilded
{
	[AutoloadEquip(EquipType.Legs)]
	public class GildedLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gilded Leggings");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 10000;
			item.rare = 4;
			item.defense = 4;
		}
		
		public override void UpdateEquip(Player player)
		{
			
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GildedBar", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}