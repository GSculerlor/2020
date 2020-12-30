using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using osuTK.Graphics;

namespace Project2020.Game.Graphics.Components.TrackList
{
    class CircularProgressPlayButton : CircularContainer
    {
        private CircularProgress progress;

        [BackgroundDependencyLoader]
        private void load()
        {
            Size = new Vector2(50);
            Masking = true;

            InternalChildren = new Drawable[]
            {
                progress = new CircularProgress
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4Extensions.FromHex(@"358879"),
                },
                new Circle
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(48),
                    Colour = Color4.White,
                },
                new SpriteIcon
                {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    Size = new Vector2(12),
                    Icon = FontAwesome.Solid.Play,
                    Colour = Color4.LightGray
                },
            };

            progress.Current.Value = 0.78f;
        }
    }
}