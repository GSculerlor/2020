using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;
using Project2020.Game.Graphics.Fonts;
using Project2020.Game.Models;

namespace Project2020.Game.Graphics.Components.TrackList
{
    public class TrackListScreen : CompositeDrawable
    {

        private FillFlowContainer<TrackRow> trackListContainer;

        public TrackListScreen()
        {
            RelativeSizeAxes = Axes.Both;
        }

        [BackgroundDependencyLoader]
        private void load(BindableList<TrackSong> trackList)
        {
            AddRangeInternal(new Drawable[]
            {
                new BasicScrollContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Child = trackListContainer = new FillFlowContainer<TrackRow>
                    {
                        Direction = FillDirection.Vertical,
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y,
                        Spacing = new Vector2(20),
                    },
                }
            });

            foreach (var track in trackList)
                trackListContainer.Add(new TrackRow(track));
        }

        private class TrackRow : CompositeDrawable
        {
            public TrackSong TrackModel { get; }

            public TrackRow(TrackSong track)
            {
                RelativeSizeAxes = Axes.X;
                Height = 50;
                Masking = true;

                TrackModel = track;

                InternalChildren = new Drawable[]
                {
                    new SpriteText
                    {
                        Text = track.SongName,
                        Font = FontsManager.GetFont(weight: FontWeight.Medium),
                        Colour = Color4.DarkGray
                    },
                };

            }
        }
    }
}