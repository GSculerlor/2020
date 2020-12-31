using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.IO.Stores;
using Project2020.Game.Models;

namespace Project2020.Game.Audio
{
    public class AudioTrackManager : Component
    {
        private readonly BindableDouble muteBindable = new BindableDouble();

        [Resolved]
        private AudioManager audio { get; set; }

        private AudioTrackStore trackStore;

        protected TrackManagerAudioTrack CurrentTrack;

        [BackgroundDependencyLoader]
        private void load()
        {
            trackStore = new AudioTrackStore(new OnlineStore());

            audio.AddItem(trackStore);
            trackStore.AddAdjustment(AdjustableProperty.Volume, audio.VolumeTrack);
        }

        public AudioTrack Get(TrackSong trackSong)
        {
            var track = CreatePreviewTrack(trackSong, trackStore);

            track.Started += () => Schedule(() =>
            {
                CurrentTrack?.Stop();
                CurrentTrack = track;
                audio.Tracks.AddAdjustment(AdjustableProperty.Volume, muteBindable);
            });

            track.Stopped += () => Schedule(() =>
            {
                if (CurrentTrack != track)
                    return;

                CurrentTrack = null;
                audio.Tracks.RemoveAdjustment(AdjustableProperty.Volume, muteBindable);
            });

            return track;
        }

        protected virtual TrackManagerAudioTrack CreatePreviewTrack(TrackSong trackSong, ITrackStore trackStore) =>
            new TrackManagerAudioTrack(trackSong, trackStore);

        public class TrackManagerAudioTrack : AudioTrack
        {
            private readonly TrackSong trackSong;
            private readonly ITrackStore trackManager;

            public TrackManagerAudioTrack(TrackSong trackSong, ITrackStore trackManager)
            {
                this.trackSong = trackSong;
                this.trackManager = trackManager;
            }

            protected override Track GetTrack() => trackManager.Get($"{trackSong.TrackDir}");
        }

        private class AudioTrackStore : AudioCollectionManager<AdjustableAudioComponent>, ITrackStore
        {
            private readonly IResourceStore<byte[]> store;

            internal AudioTrackStore(IResourceStore<byte[]> store)
            {
                this.store = store;
            }

            public Track GetVirtual(double length = double.PositiveInfinity)
            {
                if (IsDisposed) throw new ObjectDisposedException($"Cannot retrieve items for an already disposed {nameof(AudioTrackStore)}");

                var track = new TrackVirtual(length);
                AddItem(track);
                return track;
            }

            public Track Get(string name)
            {
                if (IsDisposed) throw new ObjectDisposedException($"Cannot retrieve items for an already disposed {nameof(AudioTrackStore)}");

                if (string.IsNullOrEmpty(name)) return null;

                var dataStream = store.GetStream(name);

                if (dataStream == null)
                    return null;

                Track track = new TrackBass(dataStream);
                AddItem(track);
                return track;
            }

            public Task<Track> GetAsync(string name) => Task.Run(() => Get(name));

            public Stream GetStream(string name) => store.GetStream(name);

            public IEnumerable<string> GetAvailableResources() => store.GetAvailableResources();
        }
    }
}