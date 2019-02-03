using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Glacial
{
	[AutoloadEquip(EquipType.Body)]
	public class GlacialChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Glacial Chestplate");
			Tooltip.SetDefault("");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 32;
			item.value = 10000;
			item.rare = 3;
			item.defense = 6;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.minionDamage += 0.05f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "IceCrystal", 18);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}