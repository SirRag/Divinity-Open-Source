using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Viridian
{
	public class ViridianSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Viridian Saber");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.damage = 200000;
			item.melee = true;
			item.width = 100;
			item.height = 108;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 10000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}
