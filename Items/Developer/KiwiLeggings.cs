using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Divinity.Items.Developer
{
	[AutoloadEquip(EquipType.Legs)]
	public class KiwiLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("KiwiHermit's Leggings");
			Tooltip.SetDefault("'Great for impersonating Devs!");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 10000;
			item.rare = 9;
		}
	}
}