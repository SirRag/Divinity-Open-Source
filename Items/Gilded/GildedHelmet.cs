using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Divinity.Items.Gilded
{
	[AutoloadEquip(EquipType.Head)]
	public class GildedHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gilded Helmet");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.value = 10000;
			item.rare = 4;
			item.defense = 3;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GildedChestplate") && legs.type == mod.ItemType("GildedLeggings");
		}
		
		public override void UpdateEquip(Player player)
		{
			
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