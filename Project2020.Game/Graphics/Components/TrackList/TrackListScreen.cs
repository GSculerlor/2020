using System;
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;
using Project2020.Game.Audio;
using Project2020.Game.Graphics.Fonts;
using Project2020.Game.Models;

namespace Project2020.Game.Graphics.Components.TrackList
{
    [Cached(typeof(IAudioTrackOwner))]
    public class TrackListScreen : CompositeDrawable, IAudioTrackOwner
    {

        private FillFlowContainer<TrackRow> trackListContainer;

        public TrackListScreen()
        {
            RelativeSizeAxes = Axes.Both;
        }

        [BackgroundDependencyLoader]
        private void load(List<TrackSong> trackList)
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

            public AudioTrack Audio => playButton.TrackPreview;

            public Bindable<bool> AudioPlaying => playButton?.AudioPlayingState;

            private CircularProgressPlayButton playButton;
            private SpriteText title;
            private SpriteIcon heartIcon;

            public TrackRow(TrackSong track)
            {
                Width = 600;
                Height = 50;
                Masking = true;

                TrackModel = track;
            }

            [BackgroundDependencyLoader]
            private void load(Bindable<TrackSong> activeTrack)
            {
                InternalChild = new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        playButton = new CircularProgressPlayButton(TrackModel),
                        title = new SpriteText
                        {
                            Origin = Anchor.CentreLeft,
                            Anchor = Anchor.CentreLeft,
                            Text = TrackModel.SongName,
                            Font = FontsManager.GetFont(size: 20, weight: FontWeight.Medium),
                            Colour = Color4.DarkGray,
                            Margin = new MarginPadding { Left = 80 },
                            Padding = new MarginPadding { Bottom = 2 }
                        },
                        heartIcon = new SpriteIcon
                        {
                            Origin = Anchor.CentreRight,
                            Anchor = Anchor.CentreRight,
                            Size = new Vector2(16),
                            Icon = FontAwesome.Solid.Heart,
                            Colour = Color4.LightGray
                        }
                    }
                };

                activeTrack.BindValueChanged(onActiveTrackChanged);
            }

            protected override void Update()
            {
                base.Update();

                if (AudioPlaying.Value && Audio != null && Audio.TrackLoaded)
                    playButton.Progress.Current.Value = Audio.CurrentTime / Audio.Length;
                else
                    playButton.Progress.Current.Value = 0;
            }

            private void onActiveTrackChanged(ValueChangedEvent<TrackSong> r)
            {
                if (r.NewValue == TrackModel)
                {
                    heartIcon.Colour = Color4Extensions.FromHex(@"358879");
                    title.Colour = Color4.Black;
                }
                else
                {
                    heartIcon.Colour = Color4.LightGray;
                    title.Colour = Color4.DarkGray;
                }
            }
        }
    }
}