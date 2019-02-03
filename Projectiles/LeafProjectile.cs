
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Projectiles
{
    public class LeafProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blunderbuss");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 12;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                int num3;
                for (int num492 = 0; num492 < 3; num492 = num3 + 1)
                {
                    float num493 = -projectile.velocity.X * (float)Main.rand.Next(20, 21) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
                    float num494 = -projectile.velocity.Y * (float)Main.rand.Next(20, 21) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
                    Projectile.NewProjectile(projectile.position.X + num493, projectile.position.Y + num494, num493, num494, mod.ProjectileType("Leaf1Projectile"), (int)((double)projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
                    num3 = num492;
                }
            }
        }   

        public override void AI()
        {
            int num;
            for (int num368 = 0; num368 < 3; num368 = num + 1)
            {
                float num369 = projectile.velocity.X / 2f * (float)num368;
                float num370 = projectile.velocity.Y / 2f * (float)num368;
                int num371 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num371].position.X = projectile.Center.X - num369;
                Main.dust[num371].position.Y = projectile.Center.Y - num370;
                Main.dust[num371].noGravity = true;
                Dust dust3 = Main.dust[num371];
                dust3.velocity *= 0f;
                Main.dust[num371].scale = 0.5f;
                num = num368;
            }
        }
    }
}