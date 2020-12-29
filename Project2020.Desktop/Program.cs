using osu.Framework.Platform;
using osu.Framework;
using Project2020.Game;

namespace Project2020.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"Project2020"))
            using (osu.Framework.Game game = new Project2020Game())
                host.Run(game);
        }
    }
}
