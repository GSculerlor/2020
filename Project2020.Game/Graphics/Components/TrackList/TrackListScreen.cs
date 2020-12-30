using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
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
                Width = 600;
                Height = 50;
                Masking = true;

                TrackModel = track;

                InternalChild = new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new CircularProgressPlayButton(),
                        new SpriteText
                        {
                            Origin = Anchor.CentreLeft,
                            Anchor = Anchor.CentreLeft,
                            Text = track.SongName,
                            Font = FontsManager.GetFont(size: 20, weight: FontWeight.Medium),
                            Colour = Color4.DarkGray,
                            Margin = new MarginPadding { Left = 80 },
                            Padding = new MarginPadding { Bottom = 2 }
                        },
                        new SpriteIcon
                        {
                            Origin = Anchor.CentreRight,
                            Anchor = Anchor.CentreRight,
                            Size = new Vector2(16),
                            Icon = FontAwesome.Solid.Heart,
                            Colour = Color4.LightGray
                        }
                    }
                };
            }
        }
    }
}