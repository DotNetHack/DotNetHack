using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Dungeon.Tiles;
using DotNetHack.Game.Interfaces;
using DotNetHack.UI;

namespace DotNetHack.Game.Dungeon
{
    /// <summary>
    /// DungeonRenderer
    /// </summary>
    [Serializable()]
    public class DungeonRenderer
    {
        /// <summary>
        /// DungeonRenderer
        /// </summary>
        /// <param name="aDungeon"></param>
        public DungeonRenderer(Dungeon3 aDungeon)
        {
            RenderDungeon = aDungeon;               // must be set first
            RenderBuffer = new Tile[Width, Height];
            ClearBuffer();
        }

        /// <summary>
        /// IterateXY
        /// </summary>
        /// <param name="aMapIterator"></param>
        void IterateXY(IterXYDelegate aMapIterator)
        {
            for (int x = 0; x < Width; ++x)
                for (int y = 0; y < Height; ++y)
                    aMapIterator(x, y);
        }

        /// <summary>
        /// Clears a render buffer location.
        /// </summary>
        /// <param name="l"></param>
        public void ClearLocation(Location2i l)
        {
            RenderBuffer[l.X, l.Y].G = '\0';
        }

        /// <summary>
        /// ClearBuffer
        /// </summary>
        public void ClearBuffer()
        {
            IterateXY(delegate(int x, int y)
            {
                RenderBuffer[x, y] = new Tile() { G = '\0', TileType = TileType.NOTHING };
            });
        }

        /// <summary>
        /// HardRefresh
        /// </summary>
        /// <param name="l"></param>
        public void HardRefresh(Location3i l)
        {
            IterateXY(delegate(int x, int y)
            {
                UI.Graphics.CursorToLocation(x, y);
                RenderDungeon.MapData[x, y, l.D].C.Set();
                Console.Write(RenderDungeon.MapData[x, y, l.D].G);
                RenderBuffer[x, y].G = RenderDungeon.MapData[x, y, l.D].G;
                UI.Graphics.CursorToLocation(x, y);
            });
        }

        /// <summary>
        /// RefreshBufferedRegion, refreshes the buffer for a two dimensional region
        /// of the screen.  The reason that <see cref="Location3i"/> is passed is that
        /// we need to know the dungeon level so that we draw the correct boundground data.
        /// </summary>
        /// <param name="l">The location (dungeon level to render with)</param>
        /// <param name="r">The buffered region to re-render/ refresh.</param>
        public void RefreshBufferedRegion(Location3i l, DisplayRegion r)
        {
            for (int x = r.P1.X; x < r.P2.X; ++x)
                for (int y = r.P1.Y; y <= r.P2.Y; ++y)
                {
                    UI.Graphics.CursorToLocation(x, y);
                    RenderDungeon.MapData[x, y, l.D].C.Set();
                    Console.Write(RenderDungeon.MapData[x, y, l.D].G);
                    RenderBuffer[x, y].G = RenderDungeon.MapData[x, y, l.D].G;
                }
        }

        /// <summary>
        /// Render, renders the Dungeon that this DungeonRenderer is wired to.
        /// </summary>
        /// <param name="l">This location/point is refreshed, because we assume the player moved.</param>
        public void Render(Location3i l)
        {
#if FOG_OF_WAR
            // TODO: This shit should be else where, and may even benefit from 
            // being called as part of several methods in a multicast delegate that
            // run each time render is called on a location.
            RenderDungeon.FogOfWar.UpdateSeenData(l, 6);
#endif

            IterateXY(delegate(int x, int y)
            {
#if FOG_OF_WAR
                if (RenderDungeon.FogOfWar.Seen(x, y, l.D))
#endif
                if (RenderBuffer[x, y].G != RenderDungeon.MapData[x, y, l.D].G)
                {
                    UI.Graphics.CursorToLocation(x, y);
                    if (RenderDungeon.MapData[x, y, l.D].Items.Count <= 0)
                        RenderDungeon.MapData[x, y, l.D].C.Set();
                    else RenderDungeon.MapData[x, y, l.D].Items.Peek().C.Set();
                    Console.Write(RenderDungeon.MapData[x, y, l.D].G);
                    RenderBuffer[x, y].G = RenderDungeon.MapData[x, y, l.D].G;
                    UI.Graphics.CursorToLocation(x, y);
                }
            });

            ClearLocation(l);
        }

        /// <summary>
        /// DungeonLevelGlyphs enumerable
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGlyph> DungeonLevelGlyphs()
        {
            for (int x = 0; x < Width; ++x)
                for (int y = 0; y < Height; ++y)
                    yield return RenderBuffer[x, y];
        }

        /// <summary>
        /// DungeonWidth
        /// </summary>
        public int Width { get { return RenderDungeon.DungeonWidth; } }

        /// <summary>
        /// DungeonHeight
        /// </summary>
        public int Height { get { return RenderDungeon.DungeonHeight; } }

        /// <summary>
        /// The render buffer
        /// </summary>
        IGlyph[,] RenderBuffer { get; set; }

        /// <summary>
        /// The dungeon renderer.
        /// </summary>
        Dungeon3 RenderDungeon { get; set; }
    }

}
