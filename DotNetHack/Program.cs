using System;
using System.Net.Mail;
using System.Xml.Serialization;
using DotNetHack.Core;
using DotNetHack.Definitions;

namespace DotNetHack
{
    /// <summary>
    /// The entry point for DotNetHack
    /// </summary>
    public static class EntryPoint
    {
        private static void Main(string[] args)
        {
            var l0 = new LocationIndexedCollection<Actor>
            {
                new Actor { Location = Location.Origin}
            };

            var xmlSerializer = new XmlSerializer(typeof(LocationIndexedCollection<Actor>));

            xmlSerializer.Serialize(Console.Out, l0);

            const string cTempMainPak = "Main.pak";

            new Engine(cTempMainPak).Run();
        }
    }
}