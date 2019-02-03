using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Handguns
{
	public class PolarStar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Polar Star");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.damage = 7;
			item.ranged = true;
			item.useTime = 20;
            item.scale = 0.9f;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
            item.value = 10000;
			item.rare = 8;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override Vector2? HoldoutOffset()
        {
            return new Vector2(2, -3);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("PolarProjectile");
            }
            return true;
        }
    }
}