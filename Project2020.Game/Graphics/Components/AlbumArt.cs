using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK.Graphics;

namespace Project2020.Game.Graphics.Components
{
    public class AlbumArt : CompositeDrawable
    {

        [BackgroundDependencyLoader]
        private void load()
        {
            Masking = true;

            AddInternal(new AlbumSprite());
        }

        private class AlbumSprite : BufferedContainer
        {
            [BackgroundDependencyLoader]
            private void load(LargeTextureStore texture)
            {
                RelativeSizeAxes = Axes.Both;
                Masking = true;
                CornerRadius = 20;
                CacheDrawnFrameBuffer = true;

                Children = new Drawable[]
                {
                    new Container
                    {
                        RelativeSizeAxes = Axes.Both,
                        Children = new[]
                        {
                            new Sprite
                            {
                                RelativeSizeAxes = Axes.Both,
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                FillMode = FillMode.Fill,
                                Texture = texture.Get("https://upload.wikimedia.org/wikipedia/en/2/2d/Ano_Yume_o_Nazotte_cover_art.jpg")
                            },
                        },
                    },
                };
            }
        }
    }
}