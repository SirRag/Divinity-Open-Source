using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
 
 
namespace Divinity
{
    public class DivinityWorld : ModWorld
    {
		
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("Divine Biome", delegate (GenerationProgress progress)
            {
                progress.Message = "Divine Biome Progress";
                for (int i = 0; i < Main.maxTilesX / 900; i++)       
                {
                    int X = WorldGen.genRand.Next(1, Main.maxTilesX - 300);
                    int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer - 100, Main.maxTilesY - 200);
                    int TileType = mod.TileType("DivineDirtTile");     
 
                    WorldGen.TileRunner(X, Y, 250, WorldGen.genRand.Next(100, 200), TileType, false, 0f, 0f, true, true); 
 
                }
 
            }));
        }
		public static bool spawnOre = false;
    }
}

