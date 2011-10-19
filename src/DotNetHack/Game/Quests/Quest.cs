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
        /// <summary>
        /// 
        /// </summary>
        public Quest(Func<Player, bool> c)
        {
            CompletionCriteria = c;
        }

        /// <summary>
        /// all subquests
        /// </summary>
        public LinkedList<Quest> SubQuests { get; set; }

        /// <summary>
        /// the amount of experience awarded for completing this quest
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// the name of this quest
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the quest's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// CompletionCriteria
        /// </summary>
        public readonly Func<Player, bool> CompletionCriteria { get; set; }

        /// <summary>
        /// QuestEvent
        /// </summary>
        public class QuestEvent : GameEventArgs
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="aQuest"></param>
            public QuestEvent(Quest aQuest) { Quest = aQuest; }

            /// <summary>
            /// 
            /// </summary>
            public Quest Quest { get; set; }
        }
    }
}
