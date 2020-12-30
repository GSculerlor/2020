using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using Project2020.Game.Models;
using Project2020.Resources;

namespace Project2020.Game
{
    public class Project2020GameBase : osu.Framework.Game
    {
        [Cached]
        protected readonly BindableList<TrackSong> TrackList = new BindableList<TrackSong>();

        protected override Container<Drawable> Content { get; }

        private DependencyContainer dependencies;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        protected Project2020GameBase()
        {
            base.Content.Add(Content = new DrawSizePreservingFillContainer());
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            //Resource store
            Resources.AddStore(new DllResourceStore(typeof(Project2020Resources).Assembly));

            var largeStore = new LargeTextureStore(Host.CreateTextureLoaderStore(new NamespacedResourceStore<byte[]>(Resources, @"Textures")));
            largeStore.AddStore(Host.CreateTextureLoaderStore(new OnlineStore()));
            dependencies.Cache(largeStore);

            dependencies.CacheAs(this);

            //Fonts
            AddFont(Resources, @"Fonts/Raleway-Regular");
            AddFont(Resources, @"Fonts/Raleway-Light");
            AddFont(Resources, @"Fonts/Raleway-Medium");
            AddFont(Resources, @"Fonts/Raleway-SemiBold");
            AddFont(Resources, @"Fonts/Raleway-Bold");
            AddFont(Resources, @"Fonts/Raleway-Black");

            AddFont(Resources, @"Fonts/Noto-Basic");
            AddFont(Resources, @"Fonts/Noto-Hangul");
            AddFont(Resources, @"Fonts/Noto-CJK-Basic");
            AddFont(Resources, @"Fonts/Noto-CJK-Compatibility");
            AddFont(Resources, @"Fonts/Noto-Thai");

            loadTrackList();
        }

        private void loadTrackList()
        {
            using (Stream stream = Resources.GetStream("Config/tracklist.json"))
            using (var sr = new StreamReader(stream))
                TrackList.AddRange(JsonConvert.DeserializeObject<List<TrackSong>>(sr.ReadToEnd()));
        }
    }
}
