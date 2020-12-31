using JetBrains.Annotations;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using Project2020.Game.Models;

namespace Project2020.Game.Graphics.Components
{
    public class AlbumArt : CompositeDrawable
    {
        private AlbumSprite sprite;

        [BackgroundDependencyLoader]
        private void load(Bindable<TrackSong> activeTrack)
        {
            Masking = true;

            AddInternal(sprite = new AlbumSprite());

            activeTrack.BindValueChanged(onActiveTrackChanged);
        }

        private void onActiveTrackChanged(ValueChangedEvent<TrackSong> r)
        {
            if (r.NewValue != null)
            {
                sprite.TrackSong = r.NewValue;
            }
        }

        private class AlbumSprite : ModelBackedDrawable<TrackSong>
        {
            public TrackSong TrackSong
            {
                get => Model;
                set => Model = value;
            }

            public AlbumSprite(TrackSong trackSong = null)
            {
                TrackSong = trackSong;

                RelativeSizeAxes = Axes.Both;
                Masking = true;
                CornerRadius = 20;
            }
            protected override double LoadDelay => 200;

            [Resolved]
            private LargeTextureStore texture { get; set; }

            protected override Drawable CreateDrawable([CanBeNull] TrackSong model)
            {
                if (model == null)
                    return null;

                var album = new Sprite
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillMode = FillMode.Fill,
                    Texture = texture.Get($"{model.AlbumPath}")
                };

                album.OnLoadComplete += d => d.FadeInFromZero(300, Easing.OutQuint);

                return album;
            }
        }
    }
}