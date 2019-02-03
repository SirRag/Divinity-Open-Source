using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Divinity.Items.Glacial
{
	[AutoloadEquip(EquipType.Head)]
	public class GlacialHood : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.value = 10000;
			item.rare = 3;
			item.defense = 3;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GlacialChestplate") && legs.type == mod.ItemType("GlacialLeggings");
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.minionDamage += 0.05f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "IceCrystal", 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}