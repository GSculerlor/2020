using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using Project2020.Game.Graphics.Fonts;
using osu.Framework.Graphics.Sprites;
using osuTK.Graphics;
using osuTK;

namespace Project2020.Game.Graphics.Components
{
    public class SongHeader : Container
    {
        public SongHeader()
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;

            Child = new FillFlowContainer
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(0, -10),
                AutoSizeAxes = Axes.Y,
                RelativeSizeAxes = Axes.X,
                Children = new Drawable[]
                {
                    new SpriteText
                    {
                        Text = "R Sound Design",
                        Font = FontsManager.GetFont(size: 40, weight: FontWeight.Black),
                        Colour = Color4.LightGray,
                        RelativeSizeAxes = Axes.X,
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                        Truncate = true,
                        Spacing = new Vector2(2, 0)
                    },
                    new SpriteText
                    {
                        Text = "Urban Planning of Mercury",
                        Font = FontsManager.GetFont(size: 80, weight: FontWeight.Black),
                        Colour = Color4.Black,
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                        RelativeSizeAxes = Axes.X,
                        Truncate = true,
                    },
                }
            };
        }

    }
}