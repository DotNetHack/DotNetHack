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
    [Serializable]
    public class Door : Tile, IGlyph, IHasLock, IHasLocation
    {
        /// <summary>
        /// Creates a new instance of Door.
        /// </summary>
        public Door(bool aOpen = false, bool aLocked = false)
            : base('+', Colour.Door, TileFlags.Door)
        {
            InternalDoorState = aOpen ?
                DoorState.Opened : Door.DoorState.Closed;
            IsLocked = aLocked;
            if (IsLocked) InternalDoorState = DoorState.Closed;
        }

        private enum DoorState { Opened, Closed }
        private DoorState InternalDoorState { get; set; }
        public bool IsOpen { get { return InternalDoorState == DoorState.Opened; } }
        public bool IsClosed { get { return InternalDoorState == DoorState.Closed; } }
        public bool IsLocked { get; set; }

        public virtual void CloseDoor()
        {
            if (Dice.D(5))
                GameEngine.DoSound(new Sound(this, 40, "Thud!"));
            else if (Dice.D(5))
                GameEngine.DoSound(new Sound(this, 40, "Ka-chunk!"));
            InternalDoorState = DoorState.Closed;
        }

        public virtual void OpenDoor()
        {
            if (Dice.D(5))
                GameEngine.DoSound(new Sound(10, "Creeek ..."));
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
        public static Door NewDoor(Guid aGuid, bool aOpen = false)
        {
            return new Door(aOpen, true) { KeyRef = aGuid };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aOpen"></param>
        /// <returns></returns>
        public static Door NewDoor(bool aOpen = false)
        {
            return new Door(aOpen) { KeyRef = Guid.Empty };
        }

        /// <summary>
        /// NewDoor
        /// </summary>
        /// <param name="l">The location of the door</param>
        /// <param name="open">Is the door open?</param>
        /// <returns>The new door</returns>
        public static Door NewDoor(Location3i l, bool open = false) 
        {
            var retVal = new Door(open) { KeyRef = Guid.Empty };
            retVal.Location = l;
            return retVal;
        }

        /// <summary>
        /// KeyRef
        /// </summary>
        public Guid KeyRef { get; set; }

        /// <summary>
        /// The location of the door.
        /// <remarks>Used for sound.</remarks>
        /// </summary>
        public Location3i Location { get; set; }

        /// <summary>
        /// Represents a closed door
        /// </summary>
        const char DOOR__CLOSED_GLYPH = '+';

        /// <summary>
        /// Represents an open door.
        /// </summary>
        const char DOOR__OPENED_GLYPH = '/';

        public bool UnLock(IKey aKey)
        {
            if (IsLocked)
                if (aKey.KeyGuid.Equals(KeyRef))
                {
                    GameEngine.DoSound(new Sound(this, 30, "click"));
                    IsLocked = false;
                }
            return IsLocked;
        }
    }
}
