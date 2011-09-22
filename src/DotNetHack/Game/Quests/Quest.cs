using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Events;

namespace DotNetHack.Game.Quests
{
    public class Quest
    {
        public Quest() { }
        
        public Quest[] SubQuest { }

        public int Experience { get; set; }

        public class QuestEvent : GameEventArgs
        {
            public QuestEvent(Quest aQuest) { Quest = aQuest; }
            public Quest Quest { get; set; }
        }
    }
}
