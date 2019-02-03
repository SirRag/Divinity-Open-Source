using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Divinity.Items.Developer
{
	[AutoloadEquip(EquipType.Legs)]
	public class RagLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ragnarok's Trousers");
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