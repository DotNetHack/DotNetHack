using System;
using DotNetHack.Game.Dungeon.Tiles;
using System.Collections.Generic;

namespace DotNetHack.Game.Dungeon.Generator
{
    /// <summary>
    /// DungeonGeneratorOutdoors
    /// </summary>
    public class DungeonGeneratorOutdoors : IDungeonGenerator
    {
        /// <summary>
        /// DungeonGeneratorOutdoors
        /// </summary>
        /// <param name="aEmptyDungeon"></param>
        public void Generate(Dungeon3 aDungeon)
        {
            aDungeon.IterateDungeonData(delegate(int x, int y, int d)
            {
                if (d != 0)
                    return;

                // 1/10th of 1% chance to generate a flower in the grass.
                if (Dice.D(0.1))
                {
                    var flowerColor = Dice.RandomChoice<Colour>(new List<Colour>() 
                     {   
                         new Colour(ConsoleColor.Magenta, ConsoleColor.Green),
                         new Colour(ConsoleColor.Red, ConsoleColor.Green),
                         new Colour(ConsoleColor.Yellow, ConsoleColor.Green),
                         new Colour(ConsoleColor.DarkMagenta, ConsoleColor.Green),
                     });

                    aDungeon.SetTile(x, y, d, new Tile()
                    {
                        G = '"',
                        C = flowerColor,
                        TileType = TileType.Grass,
                    });
                }
                else if (Dice.D(0.5))
                {
                    aDungeon.SetTile(x, y, d, new Tile()
                    {
                        G = 'T',
                        C = Colour.CurrentColour,
                        TileType = TileType.Tree,
                    });
                }
                else
                {
                    aDungeon.SetTile(x, y, d, new Tile()
                    {
                        G = '.',
                        C = Colour.Grass,
                        TileType = TileType.Grass,
                    });
                }

            });
        }
    }
}
