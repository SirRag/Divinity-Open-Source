using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items
{
	public class ShinyBlackSlab : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Shiny Black Slab");
			Tooltip.SetDefault("Summons a pet Android.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = mod.ProjectileType("Android");
			item.buffType = mod.BuffType("AndroidBuff");
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}