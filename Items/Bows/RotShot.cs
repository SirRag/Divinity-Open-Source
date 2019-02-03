using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Items.Bows
{
    public class RotShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rot Shot");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.useTime = 35;
            item.scale = 0.9f;
            item.useAnimation = 35;
            item.useStyle = 5;
            item.noMelee = true; 
            item.knockBack = 4;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 10; 
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, -3);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 3; 
            float rotation = MathHelper.ToRadians(6);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 0.7f;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
 