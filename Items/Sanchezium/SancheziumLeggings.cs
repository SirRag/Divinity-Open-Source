using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Divinity.Items.Sanchezium
{
	[AutoloadEquip(EquipType.Legs)]
	public class SancheziumLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gragor Leggings");
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
			player.maxMinions += 1;
			player.minionDamage += 0.05f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SancheziumBar", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}