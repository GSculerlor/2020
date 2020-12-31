using System;
using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Threading;

namespace Project2020.Game.Audio
{
    [LongRunningLoad]
    public abstract class AudioTrack : Component
    {
        public event Action Stopped;

        public event Action Started;

        protected Track Track { get; private set; }

        private bool hasStarted;

        [BackgroundDependencyLoader]
        private void load()
        {
            Track = GetTrack();
            if (Track != null)
                Track.Completed += Stop;
        }

        public double Length => Track?.Length ?? 0;

        public double CurrentTime => Track?.CurrentTime ?? 0;

        public bool TrackLoaded => Track?.IsLoaded ?? false;

        public bool IsRunning => Track?.IsRunning ?? false;

        private ScheduledDelegate startDelegate;

        public bool Start()
        {
            if (Track == null)
                return false;

            startDelegate = Schedule(() =>
            {
                if (hasStarted)
                    return;

                hasStarted = true;

                Track.Restart();
                Started?.Invoke();
            });

            return true;
        }

        public void Stop()
        {
            startDelegate?.Cancel();

            if (Track == null)
                return;

            if (!hasStarted)
                return;

            hasStarted = false;

            Track.Stop();

            Stopped?.Invoke();
        }

        protected abstract Track GetTrack();
    }
}