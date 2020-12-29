using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using Project2020.Game.Graphics.Components;
using Project2020.Game.Graphics.Fonts;

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
                    Text = "ganen. 2020.",
                    Font = FontsManager.GetFont(weight: FontWeight.SemiBold),
                    Colour = Color4.Black
                },
                new Container
                {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new AlbumArt
                        {
                            Origin = Anchor.Centre,
                            Anchor = Anchor.Centre,
                            Size = new Vector2(300),
                        },
                    }
                }
            };
        }
    }
}
