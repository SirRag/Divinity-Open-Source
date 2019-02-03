using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Divinity.Items.GraniteBoss
{
	[AutoloadEquip(EquipType.Head)]
	public class GraniteBossMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Granite Basilisk Mask ");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.value = 10000;
			item.rare = 1;
		}
	}
}