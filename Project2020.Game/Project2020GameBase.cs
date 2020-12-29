using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osuTK;
using Project2020.Resources;

namespace Project2020.Game
{
    public class Project2020GameBase : osu.Framework.Game
    {
        protected override Container<Drawable> Content { get; }

        protected Project2020GameBase()
        {
            base.Content.Add(Content = new DrawSizePreservingFillContainer());
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Resources.AddStore(new DllResourceStore(typeof(Project2020Resources).Assembly));
        }
    }
}
