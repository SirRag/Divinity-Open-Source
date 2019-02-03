using Terraria;
using Terraria.ModLoader;

namespace Divinity.Items.GraniteBoss
{
	public class GraniteBossTrophy : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Granite Basilisk Trophy");
			Tooltip.SetDefault("");
		}
		
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 50000;
			item.rare = 1;
			item.createTile = mod.TileType("GraniteBossTrophyTile");
			item.placeStyle = 0;
		}
	}
}