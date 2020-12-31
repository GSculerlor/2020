using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using Project2020.Game.Graphics.Fonts;
using osu.Framework.Graphics.Sprites;
using osuTK.Graphics;
using osuTK;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using Project2020.Game.Models;

namespace Project2020.Game.Graphics.Components
{
    public class SongHeader : Container
    {
        private SpriteText artist, title;

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
                    artist = new SpriteText
                    {
                        Text = "ganen",
                        Font = FontsManager.GetFont(size: 40, weight: FontWeight.Black),
                        Colour = Color4.LightGray,
                        RelativeSizeAxes = Axes.X,
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                        Truncate = true,
                        Spacing = new Vector2(2, 0)
                    },
                    title = new SpriteText
                    {
                        Text = "top 2020 songs, I guess",
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

        [BackgroundDependencyLoader]
        private void load(Bindable<TrackSong> activeTrack)
        {
            activeTrack.BindValueChanged(onActiveTrackChanged);
        }

        private void onActiveTrackChanged(ValueChangedEvent<TrackSong> r)
        {
            if (r.NewValue != null)
            {
                title.Text = r.NewValue.SongName;
                artist.Text = r.NewValue.SongArtist;
            }
        }
    }
}