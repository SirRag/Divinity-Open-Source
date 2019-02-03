using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.NPCs.GraniteBoss
{
    public class GraniteWeaverBody : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Weaver");
        }
        public override void SetDefaults()
        {
            npc.npcSlots = 0.001f;
            npc.width = 32;
            npc.height = 32;
            npc.aiStyle = 6;
            npc.damage = 10;
            npc.defense = 5;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
            npc.netAlways = true;
            npc.scale = 0.65f;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.dontCountMe = true;
        }
        public override void AI()
        {
            Lighting.AddLight(npc.Center, 0.5f, 0f, 0.5f);
            if (!Main.npc[(int)npc.ai[1]].active)
            {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.active = false;
            }
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        public override bool CheckActive()
        {
            return false;
        }

        public override bool PreNPCLoot()
        {
            return false;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 206, hitDirection, -1f, 10, default(Color), 1f);
            }
        }
    }
}