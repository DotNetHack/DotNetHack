using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using DotNetHack.Game.Monsters;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items;

namespace DotNetHack.Game
{
    /// <summary>
    /// LevelExtensions
    /// </summary>
    public static class LevelExtensions
    {
        /// <summary>
        /// SaveAs
        /// </summary>
        public static bool SaveAs(this DungeonLevel aLevel, string aMapFile)
        {
            try
            {
                // Create a new binary formatter
                BinaryFormatter binFormatter = new BinaryFormatter();

                using (FileStream tmpRawStream = File.Open(aMapFile,FileMode.OpenOrCreate))
                    binFormatter.Serialize(tmpRawStream, aLevel);

                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="aLevel"></param>
        /// <returns></returns>
        public static bool Save(this DungeonLevel aLevel)
        {
            return aLevel.SaveAs(aLevel.MapFile);
        }
    }

    /// <summary>
    /// Level
    /// </summary>
    [Serializable]
    public class DungeonLevel
    {
        /// <summary>
        /// Level
        /// </summary>
        public DungeonLevel()
        {
            //Monsters = new HashSet<Monster>();
            //Items = new HashSet<IItem>();
        }

        /// <summary>
        /// Level
        /// </summary>
        /// <param name="aX"></param>
        /// <param name="aY"></param>
        public DungeonLevel(int aWidth, int aHeight)
            : this()
        {
            Width = aWidth; Height = aHeight;
            Map = new Tile[aWidth, aHeight];
            RenderBuffer = new Tile[aWidth, aHeight];
            for (int w = 0; w < Width; ++w)
                for (int h = 0; h < Height; ++h)
                    Map[w, h] = new Tile() { TileType = TileType.NOTHING, G = '.' };

            // RenderBuffer[w, h] = new Tile() { TileType = TileType.NOTHING, G = '.' };

        }

        /// <summary>
        /// GetTile
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns></returns>
        public Tile GetTile(Location aLocation)
        {
            return (Tile)Map[aLocation.X, aLocation.Y];
        }

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="aLocation"></param>
        public void Render()
        {
            for (int w = 0; w < Width; ++w)
            {
                for (int h = 0; h < Height; ++h)
                {
                    // There is no reason to draw something that has not changed.
                    // Note: h != Height -1 is provided to keep the text from
                    // travelling off of the screen.
                    //if (RenderBuffer[w, h] == Map[w, h] && h != Height - 1)
                      //  continue;

                    RenderBuffer[w, h] = Map[w, h];

                    Console.SetCursorPosition(w, h);
                    Console.ForegroundColor = RenderBuffer[w, h].C;
                    Console.SetCursorPosition(w, h);
                    Console.Write(RenderBuffer[w, h].G);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write('\n');
            }
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="aMapFile">The map file to load.</param>
        /// <returns></returns>
        public static DungeonLevel Load(string aMapFile)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream tmpRawStream = File.Open(aMapFile, FileMode.Open))
                return (DungeonLevel)binFormatter.Deserialize(tmpRawStream);
        }

        /// <summary>
        /// MapFile
        /// </summary>
        public string MapFile { get; set; }

        /// <summary>
        /// backing-store for the actual raw level data
        /// without any sematic meaning(s) attached.
        /// </summary>
        public IGlyph[,] Map;

        /// <summary>
        /// RenderBuffer
        /// </summary>
        [XmlIgnore]
        public IGlyph[,] RenderBuffer;

        // The backing store for width and height.
        public int Width, Height;
    }
}

/*
using System;
using System.Collections;
using System.Collections.Generic;
namespace DotNetHack
{
	public class Level
	{
		public Level(int aWidth, int aHeight) {
			width = aWidth; height = aHeight;
			map = new char [aWidth, aHeight];
			for(int w = 0; w < width; ++w)
				for (int h = 0; h < height; ++h)
					map[w, h] = LEVEL_INIT_CHAR;
			generate();
		}
		
		public void draw() {
			for(int w = 0; w < width; ++w) {
				for (int h = 0; h < height; ++h) {
					if (!map[w, h].Equals(LEVEL_INIT_CHAR)) {
						Console.SetCursorPosition(w, h);
						Console.Write(map[w, h]);
					}
				}
				Console.Write('\n');
			}
		}
		
		public void generate() {
			
			List<string> tmpTypes = new List<string>();
			tmpTypes.Add(TYPE_HALLWAY); tmpTypes.Add(TYPE_ROOM);
			List<string> tmpDirections = new List<string>();
			tmpDirections.Add(DIR_UP); tmpDirections.Add(DIR_DOWN); 
			tmpDirections.Add(DIR_LEFT); tmpDirections.Add(DIR_RIGHT);
			int mid_width = (int)(width / 2), x = mid_width;
			int mid_height = (int)(height / 2), y = mid_height;
			
			#region First pass random walk
			for (int index = 0; index < 50; ++index) {
				switch (Utility.RandomChoice<string>.Next(tmpDirections)) {
				case DIR_UP:
					map[x, y--] = FLOOR_CHAR;
					break;
				case DIR_DOWN:
					map[x, y++] = FLOOR_CHAR;
					break;
				case DIR_LEFT:
					map[x--, y] = FLOOR_CHAR;
					break;
				case DIR_RIGHT:
					map[x++, y] = FLOOR_CHAR;
					break;
				default:
					map[x, y] = FLOOR_CHAR;
					break;
				}
			}
			#endregion
			
			#region Horizontal & Vertial orthagonal pass
			for (y = 0; y < height; ++y) {
				for(x = 0; x < width; ++x) {
					if (map[x, y].Equals(FLOOR_CHAR)) {
						// Look left
						if (map[x - 1, y].Equals(LEVEL_INIT_CHAR))
							map[x - 1, y] = Symbols.DBL_VERTICAL;
						
						// Look right
						if (map[x + 1, y].Equals(LEVEL_INIT_CHAR))
							map[x + 1, y] = Symbols.DBL_VERTICAL;
						
						// Look up
						if (map[x, y - 1].Equals(LEVEL_INIT_CHAR))
							map[x, y - 1] = Symbols.DBL_HORIZONTAL;						
						
						// Look down
						if (map[x, y + 1].Equals(LEVEL_INIT_CHAR))
							map[x, y + 1] = Symbols.DBL_HORIZONTAL;					
					}
				}
			}
			#endregion
		}

		/// <summary>
		/// backing-store for the actual raw level data
		/// without any sematic meaning(s) attached.
		/// </summary>
		char [, ] map;
		
		// The backing store for width and height.
		int width, height;
		
		#region Quick private constants for level generation,
		const char LEVEL_INIT_CHAR = ' ';
		const char FLOOR_CHAR = '.';
		const string DIR_LEFT = "left";
		const string DIR_RIGHT = "right";
		const string DIR_UP = "up";
		const string DIR_DOWN = "down";
		const string TYPE_HALLWAY = "hallway";
		const string TYPE_ROOM = "room";
		#endregion
	}
}*/

/*
if (File.Exists(aMapFileName))
    File.Delete(aMapFileName);

aMapFileName = AsMapFileName(aMapFileName);

try
{
    using (FileStream tmpRawStream = File.Open(aMapFileName, FileMode.OpenOrCreate))
    using (XmlTextWriter tmpXmlWriter = new XmlTextWriter(tmpRawStream, new UTF8Encoding()))
        new XmlSerializer(typeof(DotNetHack.World.Tile[])).Serialize(tmpXmlWriter, mapData.ToArray());
}
catch { }*/