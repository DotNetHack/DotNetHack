using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Items;

namespace DotNetHack.Game.Actions
{
   
    public class ActionPickup : DAction
    {
        public ActionPickup(Actor actor, ItemCollection itemCollection)
            : base()
        {
            ActorInvolved = actor;
            ItemCollectionInvolved = itemCollection;
        }

        public override bool Perform() 
        {

            if (ItemCollectionInvolved.Count > 0)
            {
                var item = ItemCollectionInvolved.Pop();
                ActorInvolved.Inventory.Add(item);
                return true;
            } return false;
        }

        Actor ActorInvolved { get; set; }

        ItemCollection ItemCollectionInvolved { get; set; }
    }
}
