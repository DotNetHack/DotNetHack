using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Events;
using DotNetHack.Game.Items;

namespace DotNetHack.Game.Quests
{
    /// <summary>
    /// a quest is generally a list of tasks that must be done to gain 
    /// some in-game reward.
    /// </summary>
    [Serializable]
    public class Quest : List<Task>
    {
        /// <summary>
        /// fired when the quest is completed
        /// </summary>
        public event EventHandler<QuestEventArgs> OnQuestCompleted;

        /// <summary>
        /// fired when the quest is first started
        /// </summary>
        public event EventHandler<QuestEventArgs> OnQuestStarted;

        /// <summary>
        /// supports serialization
        /// </summary>
        public Quest() { }

        /// <summary>
        /// Create a new quest
        /// </summary>
        /// <param name="name">The name of the quest</param>
        /// <param name="description">The quest description</param>
        /// <param name="experience">The experience given</param>
        /// <param name="reward">The monetary reward</param>
        public Quest(string name, string description, int experience,
            Currency reward)
        {
            QuestID = Guid.NewGuid();
            Name = name;
            Description = description;
            Experience = experience;
            Reward = reward;
            Done = false;
        }

        /// <summary>
        /// Add a task to this quest
        /// </summary>
        /// <param name="task">the task to add to this quest</param>
        public void AddTask(Task task) { Add(task); }

        /// <summary>
        /// determines if this quest has been completed by firing
        /// off all predicates against the player object.
        /// <see cref="GameEngine.Player"/>
        /// </summary>
        public bool IsComplete
        {
            get
            {
                foreach (Task t in this)
                    if (!t.Completed(GameEngine.Player))
                        return false;
                return true;
            }
        }

        /// <summary>
        /// TryCompleteQuest
        /// </summary>
        public static void TryCompleteQuest(Quest q)
        {
            if (q.IsComplete && !q.Done)
            {
                if (q.OnQuestCompleted != null)
                    q.OnQuestCompleted(q, new QuestEventArgs(q));
                q.Done = true;
                GameEngine.Player.Stats.Experience += q.Experience;
            }
        }

        /// <summary>
        /// the amount of experience points rewarded for this quest.
        /// <remarks>this is the is one of two rewards that is common to all quests</remarks>
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// the amount of currency rewarded for the completion of this quest.
        /// <remarks>this is the is one of two rewards that is common to all quests</remarks>
        /// </summary>
        public Currency Reward { get; set; }

        /// <summary>
        /// the name of this quest.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the description of this quest.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// If this quest is <c>done</c>; as in COMPLETED
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// A unique identifier
        /// </summary>
        private readonly Guid QuestID;

        [Serializable]
        /// <summary>
        /// QuestEventArgs
        /// </summary>
        public class QuestEventArgs : EventArgs
        {
            /// <summary>
            /// Create a new instance of quest event arguments
            /// </summary>
            /// <param name="aQuest">the quest involed in this argument</param>
            public QuestEventArgs(Quest aQuest) { Quest = aQuest; }

            /// <summary>
            /// the quest involved in this quest event
            /// </summary>
            public Quest Quest { get; set; }
        }

        /// <summary>
        /// ToString
        /// <remarks></remarks>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string to_s = string.Format("{0} - {1}", Name, Description);
            foreach (Task t in this)
                if (!t.Completed(GameEngine.Player))
                    to_s += "\n  » " + t.Name + " - " + t.Description;
                else
                    to_s += "\n  √ " + t.Name + " - " + t.Description;
            
            return to_s + "\n";
        }
    }
}
