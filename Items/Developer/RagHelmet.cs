using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Divinity.Items.Developer
{
	[AutoloadEquip(EquipType.Head)]
	public class RagHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ragnarok's Skull");
			
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
			return body.type == mod.ItemType("RagChestplate") && legs.type == mod.ItemType("RagLeggings");
		}
	}
}