using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetHack.Definitions;

namespace DotNetHack.Core.ScriptActions
{
    [Serializable]
    public abstract class ScriptAction
    {
        public abstract void Execute(Engine e);
    }

    [Serializable]
    public class AddItem : ScriptAction
    {
        #region Overrides of ScriptAction

        public override void Execute(Engine e)
        {
            var itemDef = e.Package.Items[ItemId];
            var objItem = new Item(itemDef);
            e.Player.Inventory.Add(objItem);
        }

        #endregion

        public string ItemId { get; set; }
    }

    [Serializable]
    public class Kill : ScriptAction
    {
        #region Overrides of ScriptAction

        public override void Execute(Engine e)
        {
            
        }

        #endregion
    }
}
