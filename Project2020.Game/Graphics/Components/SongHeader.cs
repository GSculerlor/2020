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
                AutoSizeAxes = Axes.Y,
                RelativeSizeAxes = Axes.X,
                Children = new Drawable[]
                {
                    new SpriteText
                    {
                        Text = "YOASOBI",
                        Font = FontsManager.GetFont(size: 40, weight: FontWeight.Black),
                        Colour = Color4.LightGray,
                        RelativeSizeAxes = Axes.X,
                        Truncate = true,
                        Spacing = new Vector2(2, 0)
                    },
                    new SpriteText
                    {
                        Text = "あの夢をなぞって",
                        Font = FontsManager.GetFont(size: 80, weight: FontWeight.Black),
                        Colour = Color4.Black,
                        RelativeSizeAxes = Axes.X,
                        Truncate = true,
                    },
                }
            };
        }

    }
}