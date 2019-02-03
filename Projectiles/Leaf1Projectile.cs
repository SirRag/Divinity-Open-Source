using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Projectiles
{
    public class Leaf1Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overgrown Blunderbuss");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 12;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
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