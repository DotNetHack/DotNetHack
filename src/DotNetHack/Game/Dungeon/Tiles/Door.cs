using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Dungeon.Tiles
{
    /// <summary>
    /// Door
    /// <remarks>A door is a movable structure used to close off an entrance, typically consisting of a panel that swings on hinges or that slides or rotates inside of a space.</remarks>
    /// <see cref="http://en.wikipedia.org/wiki/Door"/>
    /// </summary>
    public class Door : Tile, IGlyph
    {
        /// <summary>
        /// Creates a new instance of Door.
        /// </summary>
        public Door(bool aOpen = false)
            : base('+', Colour.Door)
        {
            InternalDoorState = aOpen ? 
                DoorState.Opened : Door.DoorState.Closed;
            TileFlags = TileFlags.Door;
        }

        private enum DoorState { Opened, Closed }
        private DoorState InternalDoorState { get; set; }
        public bool IsOpen { get { return InternalDoorState == DoorState.Opened; } }
        public bool IsClosed { get { return InternalDoorState == DoorState.Closed; } }

        public virtual void CloseDoor() 
        {
            InternalDoorState = DoorState.Closed; 
        }

        public virtual void OpenDoor() 
        {
            G = DOOR__OPENED_GLYPH;
            InternalDoorState = DoorState.Opened; 
        }

        /// <summary>
        /// override char G to be dependent upon the door state.
        /// </summary>
        public override char G
        {
            get
            {
                switch (InternalDoorState)
                { 
                    case DoorState.Closed:
                        DoorGlyph = DOOR__CLOSED_GLYPH;
                        break;
                    case DoorState.Opened:
                        DoorGlyph = DOOR__OPENED_GLYPH;
                        break;
                }

                return DoorGlyph;
            }
            set { DoorGlyph = value; }
        }

        /// <summary>
        /// The glyph used to represent this door.
        /// </summary>
        private char DoorGlyph;
        
        /// <summary>
        /// Returns a new closed door
        /// </summary>
        /// <returns></returns>
        public static Door NewDoor(bool aOpen = false)
        {
            return new Door(aOpen) { Guid = Guid.NewGuid(), };
        }

        /// <summary>
        /// Uniquely identifies this door.
        /// </summary>
        public Guid Guid { get; set; }
        
        /// <summary>
        /// Represents a closed door
        /// </summary>
        const char DOOR__CLOSED_GLYPH = '+';

        /// <summary>
        /// Represents an open door.
        /// </summary>
        const char DOOR__OPENED_GLYPH = '/';
    }
}
