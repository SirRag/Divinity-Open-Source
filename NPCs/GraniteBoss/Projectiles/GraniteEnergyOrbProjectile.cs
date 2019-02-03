using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.NPCs.GraniteBoss.Projectiles
{
    public class GraniteEnergyOrbProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Energy Orb");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.penetrate = -1;
            projectile.width = 52;
            projectile.height = 52;
            projectile.timeLeft = 40;
            projectile.melee = true;
            projectile.hostile = true;
            projectile.tileCollide = false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("GraniteEnergy"), 300, true);
        }

        public override void AI()
        {
            if (projectile.localAI[1] == 0f)
            {
                projectile.localAI[1] = 1f;
                Main.PlaySound(SoundID.Item93, projectile.position);
            }
            projectile.ai[0] += 1f;
            if (projectile.ai[1] == 1f)
            {
                if (projectile.ai[0] >= 130f)
                {
                    projectile.alpha += 10;
                }
                else
                {
                    projectile.alpha -= 10;
                }
                if (projectile.alpha < 0)
                {
                    projectile.alpha = 0;
                }
                if (projectile.alpha > 255)
                {
                    projectile.alpha = 255;
                }
                if (projectile.ai[0] >= 150f)
                {
                    projectile.Kill();
                    return;
                }
                if (projectile.ai[0] % 30f == 0f && Main.netMode != 1)
                {
                    Vector2 vector91 = projectile.rotation.ToRotationVector2();
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector91.X, vector91.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                }
                projectile.rotation += 0.104719758f;
                Lighting.AddLight(projectile.Center, 0.3f, 0.75f, 0.9f);
                return;
            }
            else
            {
                projectile.position -= projectile.velocity;
                if (projectile.ai[0] >= 40f)
                {
                    projectile.alpha += 3;
                }
                else
                {
                    projectile.alpha -= 40;
                }
                if (projectile.alpha < 0)
                {
                    projectile.alpha = 0;
                }
                if (projectile.alpha > 255)
                {
                    projectile.alpha = 255;
                }
                if (projectile.ai[0] >= 45f)
                {
                    projectile.Kill();
                    return;
                }
                Vector2 value36 = new Vector2(0f, -720f).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
                float scaleFactor7 = projectile.ai[0] % 45f / 45f;
                Vector2 spinningpoint = value36 * scaleFactor7;
                int num3;
                for (int num836 = 0; num836 < 6; num836 = num3 + 1)
                {
                    Vector2 vector92 = projectile.Center + spinningpoint.RotatedBy((double)((float)num836 * 6.28318548f / 6f), default(Vector2));
                    Lighting.AddLight(vector92, 0.3f, 0.75f, 0.9f);
                    for (int num837 = 0; num837 < 2; num837 = num3 + 1)
                    {
                        int num838 = Dust.NewDust(vector92 + Utils.RandomVector2(Main.rand, -8f, 8f) / 2f, 8, 8, 197, 0f, 0f, 100, Color.Transparent, 1f);
                        Main.dust[num838].noGravity = true;
                        num3 = num837;
                    }
                    num3 = num836;
                }
                return;
            }
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}