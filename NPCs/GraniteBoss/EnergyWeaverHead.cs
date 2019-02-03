using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.NPCs.GraniteBoss
{
    [AutoloadBossHead]
    public class EnergyWeaverHead : ModNPC
    {
        public bool flies = true;
        public bool directional = false;
        public float speed = 10f;
        public float turnSpeed = 0.10f;
        public bool SpawnSegments = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Basilisk");
        }
        public override void SetDefaults()
        {
            npc.npcSlots = 5f;
            npc.width = 32;
            npc.height = 32;
            npc.aiStyle = 6;
            aiType = -1;
            npc.defense = 15;
            npc.damage = 35;
            npc.lifeMax = 3000;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
            npc.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            npc.scale = 1.15f;
            npc.boss = true;
            npc.netAlways = true;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.alpha = 255;
            music = MusicID.Boss1;
            bossBag = mod.ItemType("GraniteWYYRMboyeBag");
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = name;
            potionType = ItemID.LesserHealingPotion;
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D drawTexture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2(drawTexture.Width / 2 * 0.5f, drawTexture.Height / Main.npcFrameCount[npc.type] * 0.5f);

            Vector2 drawPos = new Vector2(
                npc.position.X - Main.screenPosition.X + npc.width / 2 - Main.npcTexture[npc.type].Width / 2 * npc.scale / 2f + origin.X * npc.scale,
                (npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY) -50 );

            SpriteEffects effects =
                npc.spriteDirection == -1
                    ? SpriteEffects.None
                    : SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);

            return false;
        }
        public override void AI()
        {
            npc.localAI[2] += 1f; //These are AI timers, they will make something happen once the timer has been reached
            if (npc.localAI[2] == 100f) //Since worms already have ai, we have to use LocalAI. Were using the LocalAI to fire projectiles on a timer.
            {
                Projectile.NewProjectile(npc.position.X, npc.position.Y, npc.velocity.X, npc.velocity.Y, 592, 20, 0f, Main.myPlayer, (float)Main.rand.Next(0, 31), 0f);
            }
            if (npc.localAI[2] == 400f) //Since worms already have ai, we have to use LocalAI. Were using the LocalAI to fire projectiles on a timer.
            {
                NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), mod.NPCType("GraniteWeaverHead"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);
            }
            if (npc.localAI[2] == 500f)
            {
                Projectile.NewProjectile(npc.position.X, npc.position.Y, npc.velocity.X, npc.velocity.Y, mod.ProjectileType("GraniteEnergyOrbProjectile"), 10, 0f, Main.myPlayer, (float)Main.rand.Next(0, 31), 0f);
                Main.PlaySound(SoundID.Item93, npc.position);
            }
            if (npc.localAI[2] == 600f)
            {
                Projectile.NewProjectile(npc.position.X, npc.position.Y, npc.velocity.X, npc.velocity.Y, mod.ProjectileType("GraniteEnergyOrbProjectile"), 10, 0f, Main.myPlayer, (float)Main.rand.Next(0, 31), 0f);
                Main.PlaySound(SoundID.Item93, npc.position); //We could make the body create these projectiles but that means it would spawn a projectile for every body segment, and theres 26 segments, so yeah.
            }
            if (npc.localAI[2] >= 600f) //this stops the timer from continuing endlessly, it sets it in a loop.
            {
                npc.localAI[2] = 0f;
                npc.localAI[0] = 0f;
            }
            Lighting.AddLight(npc.Center, 0.5f, 0f, 0.5f);
            Player player = Main.player[npc.target]; //this defines the player, which you can use to make a despawn and more.
            npc.alpha -= 5; //this is a fade in effect for the boss.
            if (npc.alpha < 0)
            {
                npc.alpha = 0;
            }

            if (!Main.npc[(int)npc.ai[1]].active) //theres bugs with the segments despawning if you kill it, some will stay alive. so if one is dead they will all despawn.
            {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.active = false;
            }
            if (!SpawnSegments) //Segment spawner
            {
                int Spawned = npc.whoAmI;
                for (int SpawnSegment = 0; SpawnSegment < 26; SpawnSegment++)
                {
                    int Spawn = 0;
                    if (SpawnSegment >= 0 && SpawnSegment < 25)
                    {
                        Spawn = NPC.NewNPC((int)((npc.position.X + (float)(npc.width / 2)) + 8), (int)(npc.position.Y + (float)npc.height), mod.NPCType("EnergyWeaverBody"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                    }
                    else
                    {
                        Spawn = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), mod.NPCType("EnergyWeaverTail"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                    }
                    Main.npc[Spawn].realLife = npc.whoAmI;
                    Main.npc[Spawn].ai[2] = npc.whoAmI;
                    Main.npc[Spawn].ai[1] = Spawned;
                    Main.npc[Spawned].ai[0] = Spawn;
                    Spawned = Spawn;
                }
                SpawnSegments = true;
            }
            int num180 = (int)(npc.position.X / 16f) - 1; //some worms stuff beyond this point
            int num181 = (int)((npc.position.X + (float)npc.width) / 16f) + 4;
            int num182 = (int)(npc.position.Y / 16f) - 1;
            int num183 = (int)((npc.position.Y + (float)npc.height) / 16f) + 4;
            if (num180 < 0)
            {
                num180 = 0;
            }
            if (num181 > Main.maxTilesX)
            {
                num181 = Main.maxTilesX;
            }
            if (num182 < 0)
            {
                num182 = 0;
            }
            if (num183 > Main.maxTilesY)
            {
                num183 = Main.maxTilesY;
            }
            bool flag18 = flies;
            if (!flag18)
            {
                for (int num184 = num180; num184 < num181; num184++)
                {
                    for (int num185 = num182; num185 < num183; num185++)
                    {
                        if (Main.tile[num184, num185] != null && ((Main.tile[num184, num185].nactive() && (Main.tileSolid[(int)Main.tile[num184, num185].type] || (Main.tileSolidTop[(int)Main.tile[num184, num185].type] && Main.tile[num184, num185].frameY == 0))) || Main.tile[num184, num185].liquid > 64))
                        {
                            Vector2 vector17;
                            vector17.X = (float)(num184 * 16);
                            vector17.Y = (float)(num185 * 16);
                            if (npc.position.X + (float)npc.width > vector17.X && npc.position.X < vector17.X + 16f && npc.position.Y + (float)npc.height > vector17.Y && npc.position.Y < vector17.Y + 16f)
                            {
                                flag18 = true;
                                if (Main.rand.Next(100) == 0 && npc.behindTiles && Main.tile[num184, num185].nactive())
                                {
                                    WorldGen.KillTile(num184, num185, true, true, false);
                                }
                                if (Main.netMode != 1 && Main.tile[num184, num185].type == 2)
                                {
                                    ushort arg_BFCA_0 = Main.tile[num184, num185 - 1].type;
                                }
                            }
                        }
                    }
                }
            }
            if (!flag18)
            {
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
                int num186 = 1000;
                bool flag19 = true;
                for (int num187 = 0; num187 < 255; num187++)
                {
                    if (Main.player[num187].active)
                    {
                        Rectangle rectangle2 = new Rectangle((int)Main.player[num187].position.X - num186, (int)Main.player[num187].position.Y - num186, num186 * 2, num186 * 2);
                        if (rectangle.Intersects(rectangle2))
                        {
                            flag19 = false;
                            break;
                        }
                    }
                }
                if (flag19)
                {
                    flag18 = true;
                }
            }
            if (directional)
            {
                if (npc.velocity.X < 0f)
                {
                    npc.spriteDirection = 1;
                }
                else if (npc.velocity.X > 0f)
                {
                    npc.spriteDirection = -1;
                }
            }
            float num188 = speed;
            float num189 = turnSpeed;
            Vector2 vector18 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num191 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
            float num192 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
            num191 = (float)((int)(num191 / 16f) * 16);
            num192 = (float)((int)(num192 / 16f) * 16);
            vector18.X = (float)((int)(vector18.X / 16f) * 16);
            vector18.Y = (float)((int)(vector18.Y / 16f) * 16);
            num191 -= vector18.X;
            num192 -= vector18.Y;
            float num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
            if (npc.ai[1] > 0f && npc.ai[1] < (float)Main.npc.Length)
            {
                try
                {
                    vector18 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    num191 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector18.X;
                    num192 = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - vector18.Y;
                }
                catch
                {
                }
                npc.rotation = (float)System.Math.Atan2((double)num192, (double)num191) + 1.50f;
                num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
                int num194 = npc.width;
                num193 = (num193 - (float)num194) / num193;
                num191 *= num193;
                num192 *= num193;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + num191;
                npc.position.Y = npc.position.Y + num192;
                if (directional)
                {
                    if (num191 < 0f)
                    {
                        npc.spriteDirection = 1;
                    }
                    if (num191 > 0f)
                    {
                        npc.spriteDirection = -1;
                    }
                }
            }
            else
            {
                if (!flag18)
                {
                    npc.TargetClosest(true);
                    npc.velocity.Y = npc.velocity.Y + 0.11f;
                    if (npc.velocity.Y > num188)
                    {
                        npc.velocity.Y = num188;
                    }
                    if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)num188 * 0.5)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - num189 * 1.3f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X + num189 * 1.3f;
                        }
                    }
                    else if (npc.velocity.Y == num188)
                    {
                        if (npc.velocity.X < num191)
                        {
                            npc.velocity.X = npc.velocity.X + num189;
                        }
                        else if (npc.velocity.X > num191)
                        {
                            npc.velocity.X = npc.velocity.X - num189;
                        }
                    }
                    else if (npc.velocity.Y > 4f)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num189 * 0.95f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X - num189 * 0.95f;
                        }
                    }
                }
                else
                {
                    if (!flies && npc.behindTiles && npc.soundDelay == 0)
                    {
                        float num195 = num193 / 43f;
                        if (num195 < 10f)
                        {
                            num195 = 10f;
                        }
                        if (num195 > 20f)
                        {
                            num195 = 20f;
                        }
                        npc.soundDelay = (int)num195;
                        Main.PlaySound(SoundID.Roar, npc.position, 1);
                    }
                    num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
                    float num196 = System.Math.Abs(num191);
                    float num197 = System.Math.Abs(num192);
                    float num198 = num188 / num193;
                    num191 *= num198;
                    num192 *= num198;
                    bool flag21 = false;
                    if (!flag21)
                    {
                        if ((npc.velocity.X > 0f && num191 > 0f) || (npc.velocity.X < 0f && num191 < 0f) || (npc.velocity.Y > 0f && num192 > 0f) || (npc.velocity.Y < 0f && num192 < 0f))
                        {
                            if (npc.velocity.X < num191)
                            {
                                npc.velocity.X = npc.velocity.X + num189;
                            }
                            else
                            {
                                if (npc.velocity.X > num191)
                                {
                                    npc.velocity.X = npc.velocity.X - num189;
                                }
                            }
                            if (npc.velocity.Y < num192)
                            {
                                npc.velocity.Y = npc.velocity.Y + num189;
                            }
                            else
                            {
                                if (npc.velocity.Y > num192)
                                {
                                    npc.velocity.Y = npc.velocity.Y - num189;
                                }
                            }
                            if ((double)System.Math.Abs(num192) < (double)num188 * 0.2 && ((npc.velocity.X > 0f && num191 < 0f) || (npc.velocity.X < 0f && num191 > 0f)))
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num189 * 2f;
                                }
                                else
                                {
                                    npc.velocity.Y = npc.velocity.Y - num189 * 2f;
                                }
                            }
                            if ((double)System.Math.Abs(num191) < (double)num188 * 0.2 && ((npc.velocity.Y > 0f && num192 < 0f) || (npc.velocity.Y < 0f && num192 > 0f)))
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + num189 * 2f;
                                }
                                else
                                {
                                    npc.velocity.X = npc.velocity.X - num189 * 2f;
                                }
                            }
                        }
                        else
                        {
                            if (num196 > num197)
                            {
                                if (npc.velocity.X < num191)
                                {
                                    npc.velocity.X = npc.velocity.X + num189 * 1.1f;
                                }
                                else if (npc.velocity.X > num191)
                                {
                                    npc.velocity.X = npc.velocity.X - num189 * 1.1f;
                                }
                                if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)num188 * 0.5)
                                {
                                    if (npc.velocity.Y > 0f)
                                    {
                                        npc.velocity.Y = npc.velocity.Y + num189;
                                    }
                                    else
                                    {
                                        npc.velocity.Y = npc.velocity.Y - num189;
                                    }
                                }
                            }
                            else
                            {
                                if (npc.velocity.Y < num192)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num189 * 1.1f;
                                }
                                else if (npc.velocity.Y > num192)
                                {
                                    npc.velocity.Y = npc.velocity.Y - num189 * 1.1f;
                                }
                                if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)num188 * 0.5)
                                {
                                    if (npc.velocity.X > 0f)
                                    {
                                        npc.velocity.X = npc.velocity.X + num189;
                                    }
                                    else
                                    {
                                        npc.velocity.X = npc.velocity.X - num189;
                                    }
                                }
                            }
                        }
                    }
                }
                npc.rotation = (float)System.Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.58f;
                if (flag18)
                {
                    if (npc.localAI[0] != 1f)
                    {
                        npc.netUpdate = true;
                    }
                    npc.localAI[0] = 1f;
                }
                else
                {
                    if (npc.localAI[0] != 0f)
                    {
                        npc.netUpdate = true;
                    }
                    npc.localAI[0] = 0f;
                }
                if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
                {
                    npc.netUpdate = true;
                    return;
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage) //dust effects
        {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 206, hitDirection, -1f, 100, default(Color), 1f);
            }
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteBossMask"));
            }
            if (Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteBossTrophy"));
            }
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Sword"));
                }
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Bow"));
                }
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Staff"));
                }
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThrowingItem"));
                }
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SummonStaff"));
                }
            }
        }
    }
}