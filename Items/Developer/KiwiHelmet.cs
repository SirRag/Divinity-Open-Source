using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Divinity.Items.Developer
{
	[AutoloadEquip(EquipType.Head)]
	public class KiwiHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("KiwiHermit's Helmet");
			Tooltip.SetDefault("'Great for impersonating Devs!");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.value = 10000;
			item.rare = 9;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("KiwiChestplate") && legs.type == mod.ItemType("KiwiLeggings");
		}
	}
}