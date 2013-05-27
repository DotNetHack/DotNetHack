using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack
{
    /// <summary>
    /// DNHObject
    /// </summary>
    public class DNHObject
    {
        public DNHObject() { }
        public DNHObject(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
