using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Divinity.NPCs
{
    public class ModGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {

			if (npc.type == NPCID.TheDestroyer)   
            {
                 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PowerStabilizer")); //Item spawn
            }

			if (npc.type == NPCID.SkeletronPrime)   
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Chassis")); //Item spawn
            }
			
			if (npc.type == NPCID.Spazmatism)   
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ControlModule")); //Item spawn
			}
			if (npc.type == NPCID.ArmsDealer)   
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ArmsDealer")); //Item spawn
			}
        }
    }
}