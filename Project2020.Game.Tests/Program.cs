using osu.Framework;
using osu.Framework.Platform;

namespace Project2020.Game.Tests
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost("visual-tests"))
            using (var game = new Project2020TestBrowser())
                host.Run(game);
        }
    }
}
