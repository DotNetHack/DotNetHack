using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game
{
    public class Ingredient
    {
        public string Name { get; set; }
        public override bool Equals(object obj) { return ((Ingredient)obj).Name.Equals(Name); }
    }
}
