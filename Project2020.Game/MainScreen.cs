using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using Project2020.Game.Graphics.Components;
using Project2020.Game.Graphics.Fonts;

namespace Project2020.Game
{
    public class MainScreen : Screen
    {
        [BackgroundDependencyLoader]
        private void load() => InternalChildren = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.White
                },
                new SpriteText
                {
                    Origin = Anchor.TopLeft,
                    Anchor = Anchor.TopLeft,
                    Margin = new MarginPadding { Top = 20, Left = 100 },
                    Text = "ganen. 2020.",
                    Font = FontsManager.GetFont(weight: FontWeight.SemiBold),
                    Colour = Color4.Black
                },
                new GridContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    ColumnDimensions = new[]
                    {
                        new Dimension(GridSizeMode.Absolute, size: 500),
                        new Dimension(GridSizeMode.Distributed)
                    },
                    Content = new[]
                    {
                        new Drawable[]
                        {
                            new Container
                            {
                                RelativeSizeAxes = Axes.Both,
                                Children = new Drawable[]
                                {
                                    new Container
                                    {
                                        Origin = Anchor.Centre,
                                        Anchor = Anchor.Centre,
                                        RelativeSizeAxes = Axes.Y,
                                        Width = 300,
                                        Margin = new MarginPadding { Top = 300 },
                                        Masking = true,
                                        CornerRadius = 20,
                                        Children = new Drawable[]
                                        {
                                            new Box
                                            {
                                                RelativeSizeAxes = Axes.Both,
                                                Colour = Color4Extensions.FromHex(@"358879"),
                                            },
                                            new Box
                                            {
                                                RelativeSizeAxes = Axes.Both,
                                                Colour = ColourInfo.GradientVertical(Color4.Black.Opacity(0.1f), Color4.Black.Opacity(0.6f)),
                                            }
                                        },
                                    },
                                    new AlbumArt
                                    {
                                        Origin = Anchor.Centre,
                                        Anchor = Anchor.Centre,
                                        Margin = new MarginPadding { Left = 100 },
                                        Size = new Vector2(300),
                                    },
                                    new SpriteText
                                    {
                                        Origin = Anchor.BottomCentre,
                                        Anchor = Anchor.BottomCentre,
                                        Margin = new MarginPadding { Bottom = 20 },
                                        Text = "track 1 of 5",
                                        Font = FontsManager.GetFont(size: 20, weight: FontWeight.Regular),
                                        Colour = Color4.White
                                    }
                                }
                            },
                            new GridContainer
                            {
                                RelativeSizeAxes = Axes.Both,
                                RowDimensions= new[]
                                {
                                    new Dimension(GridSizeMode.AutoSize),
                                    new Dimension(GridSizeMode.Distributed)
                                },
                                Content = new[]
                                {
                                    new Drawable[]
                                    {
                                        // Add hacky way to add space on first grid
                                        new Container
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            Height = 150
                                        }
                                    },
                                    new Drawable[]
                                    {
                                        new SongHeader
                                        {
                                            Margin = new MarginPadding { Left = 20 }
                                        }
                                    }
                                }
                            }
                        },
                    }
                }
            };
    }
}
