using osu.Framework.Allocation;
using osu.Framework.Platform;
using osu.Framework.Testing;

namespace Project2020.Game.Tests.Visual
{
    public class TestSceneProject2020Game : TestScene
    {
        // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
        // You can make changes to classes associated with the tests and they will recompile and update immediately.

        private Project2020Game game;

        [BackgroundDependencyLoader]
        private void load(GameHost host)
        {
            game = new Project2020Game();
            game.SetHost(host);

            Add(game);
        }
    }
}
