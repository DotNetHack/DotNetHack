namespace DotNetHack
{
    /// <summary>
    /// The entry point for DotNetHack
    /// </summary>
    public static class EntryPoint
    {
        private static void Main(string[] args)
        {
            const string cTempMainPak = "Main.pak";

            new Engine(cTempMainPak).Run();
        }
    }
}