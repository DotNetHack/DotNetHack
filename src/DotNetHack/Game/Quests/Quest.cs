using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Events;

namespace DotNetHack.Game.Quests
{
    /// <summary>
    /// Quest
    /// </summary>
    public class Quest
    {
        public Quest() 
        {
        }

        public Quest[] SubQuests { get; set; }

        public int Experience { get; set; }

        public class QuestEvent : GameEventArgs
        {
            public QuestEvent(Quest aQuest) { Quest = aQuest; }
            public Quest Quest { get; set; }
        }
    }
}
