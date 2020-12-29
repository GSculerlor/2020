using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK.Graphics;

namespace Project2020.Game
{
    public class MainScreen : Screen
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Box 
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.White
                },
                new SpriteText 
                {
                    Origin = Anchor.TopLeft,
                    Anchor = Anchor.TopLeft,
                    Margin = new MarginPadding { Top = 20, Left = 100 },
                    Text = "music.",
                    Colour = Color4.Black
                },
            };
        }
    }
}
