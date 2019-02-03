using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.Projectiles
{
    public class PolarProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 1; 
            projectile.height = 8;           
            projectile.aiStyle = 1; 
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.alpha = 255;            
            projectile.light = 0.2f;           
            projectile.ignoreWater = true;         
            projectile.tileCollide = true;        
            projectile.extraUpdates = 2;     
            aiType = ProjectileID.Bullet;       
        }

        public void CreateDust()
        {
            if (Main.rand.NextBool(2))
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 35);
                Main.dust[dust].scale = 0.5f;
            }
        }

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 0.4f);
            Main.dust[dust].noGravity = true;
            {
                Lighting.AddLight(projectile.position, 0.01f, 0.01f, 0.30f);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15);
                Main.dust[dust].scale = 0.5f;
                Main.dust[dust].noGravity = true;
            }
            Main.PlaySound(SoundID.Item10, projectile.position);
            return true;
        }
    }
}