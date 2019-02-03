using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Divinity.Items.Glacial
{
	[AutoloadEquip(EquipType.Legs)]
	public class GlacialLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 10000;
			item.rare = 3;
			item.defense = 4;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.minionDamage += 0.05f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "IceCrystal", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}