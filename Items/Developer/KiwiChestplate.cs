using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Developer
{
	[AutoloadEquip(EquipType.Body)]
	public class KiwiChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("KiwiHermit's Chestplate");
			Tooltip.SetDefault("'Great for impersonating Devs!");
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 32;
			item.value = 10000;
			item.rare = 9;
		}
	}
}