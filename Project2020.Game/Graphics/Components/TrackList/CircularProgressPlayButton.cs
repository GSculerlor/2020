using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using Project2020.Game.Audio;
using Project2020.Game.Models;

namespace Project2020.Game.Graphics.Components.TrackList
{
    class CircularProgressPlayButton : CircularContainer
    {
        public CircularProgress Progress;

        public readonly BindableBool AudioPlayingState = new BindableBool();

        public AudioTrack TrackPreview { get; private set; }

        private TrackSong trackAudio;

        public TrackSong TrackAudio
        {
            get => trackAudio;
            set
            {
                if (value == trackAudio) return;

                trackAudio = value;

                TrackPreview?.Stop();
                TrackPreview?.Expire();
                TrackPreview = null;

                AudioPlayingState.Value = false;
            }
        }

        private SpriteIcon icon;


        public CircularProgressPlayButton(TrackSong track = null)
        {
            TrackAudio = track;

            Size = new Vector2(50);
            Masking = true;

            InternalChildren = new Drawable[]
            {
                Progress = new CircularProgress
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
                icon = new SpriteIcon
                {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    Size = new Vector2(12),
                    Icon = FontAwesome.Solid.Play,
                    Colour = Color4.LightGray
                },
            };

            
            AudioPlayingState.ValueChanged += audioStateChanged;
        }

        protected override bool OnClick(ClickEvent e)
        {
            AudioPlayingState.Toggle();
            return true;
        }


        [Resolved]
        private AudioTrackManager audioTrackManager { get; set; }

        [Resolved]
        private Bindable<TrackSong> activeTrack { get; set; }

        private void audioStateChanged(ValueChangedEvent<bool> e)
        {
            icon.Icon = e.NewValue ? FontAwesome.Solid.Stop : FontAwesome.Solid.Play;
            icon.Colour = e.NewValue ? Color4Extensions.FromHex(@"358879") : Color4.LightGray;

            if (e.NewValue)
            {
                if (TrackAudio == null)
                {
                    AudioPlayingState.Value = false;
                    return;
                }

                if (TrackPreview != null)
                {
                    attemptStart();
                    return;
                }

                LoadComponentAsync(TrackPreview = audioTrackManager.Get(trackAudio), preview =>
                {
                    if (TrackPreview != preview)
                        return;

                    AddInternal(preview);
                    preview.Stopped += () => AudioPlayingState.Value = false;

                    if (AudioPlayingState.Value)
                        attemptStart();
                });
            }
            else
            {
                TrackPreview?.Stop();
                activeTrack.Value = null;
            }
        }

        private void attemptStart()
        {
            if (TrackPreview?.Start() != true)
                AudioPlayingState.Value = false;
            else
                activeTrack.Value = TrackAudio;
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            AudioPlayingState.Value = false;
            activeTrack.Value = null;
        }
    }
}