using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Developer
{
	[AutoloadEquip(EquipType.Body)]
	public class RagChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Ragnarok's Suit");
			Tooltip.SetDefault("'Great for impersonating mod Devs!");
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