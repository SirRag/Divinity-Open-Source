using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Unigite
{
	public class ControlModule : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Control Module");
            Tooltip.SetDefault("Used to craft Unigite Crafter.");		
		}
		public override void SetDefaults()
		{
			item.maxStack = 10;
			item.rare = 5;
			item.value = 3000;
		}
	}	
} 