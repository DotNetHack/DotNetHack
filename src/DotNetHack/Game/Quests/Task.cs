using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Quests
{
    
    /// <summary>
    /// A task is an automic item that belongs to quests.  For a quest to 
    /// be completed; the predicate for all contained tasks must all 
    /// be completed
    /// </summary>
    [Serializable]
    public class Task
    {
        /// <summary>
        /// supports serialization
        /// </summary>
        public Task() { }

        /// <summary>
        /// creates a new task with passed, name, description and 
        /// completion predicate. the completion predicate takes a player
        /// and returns a boolean value.
        /// </summary>
        /// <param name="name">the name of the new task</param>
        /// <param name="description">the short description for the task</param>
        /// <param name="completed">complteion predicate.</param>
        public Task(string name, string description,
            Func<Player, bool> completed)
        {
            // set the name
            Name = name;

            // set completion predicate
            Completed = completed;

            // set description
            Description = description;
        }

        /// <summary>
        /// the name of this task
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the description of this task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the completion predicate for this task.
        /// </summary>
        public Func<Player, bool> Completed { get; set; }
    }
}
