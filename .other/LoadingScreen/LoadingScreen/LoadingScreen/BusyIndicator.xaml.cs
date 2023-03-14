using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoadingScreen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusyIndicator : ContentView
    {
        private Random rnd = new Random();
        int ColCount = 0;
        int i = 0;
        bool block = true;

        public BusyIndicator(int type)
        {
            InitializeComponent();

            while (i != 27)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 10 });

                i++;
            }

            grid.RowDefinitions.Add(new RowDefinition { Height = 20 });

            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
            {
                Tick(type);

                return true;
            });
        }


        public void Tick(int type)
        {
            int y = 0;
            int x = 0;

            if (type == 1)
            {
                if (ColCount == 27)
                {
                    block = false;
                }
                else if (ColCount == 0)
                {
                    block = true;
                }
            }
            else if (type == 2)
            {
                if (ColCount == 30)
                {
                    ColCount = 0;
                }
            }
            else if (type == 3)
            {
                if (ColCount == 0)
                {
                    ColCount = 30;
                }
            }

            while (y != 1)
            {
                Color randomColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                grid.Children.Add(new Frame
                {
                    BackgroundColor = randomColor,
                    CornerRadius = 90,
                    HeightRequest = 20,
                    WidthRequest = 10,
                },
                ColCount, 0);

                if (type == 1)
                {
                    if (block == true)
                    {
                        ColCount++;
                    }
                    else
                    {
                        ColCount--;
                    }

                    if (ColCount > -1)
                    {
                        if (block == false)
                            x = ColCount + 4;
                        else
                            x = ColCount - 4;
                        if (x == -3)
                            x = 3;
                    }
                }
                else if (type == 2)
                {
                    ColCount++;

                    x = ColCount - 4;
                }
                else if (type == 3)
                {
                    ColCount--;

                    x = ColCount + 4;

                    if (x >= 30)
                        x = x - 29;
                }
                
                var eList = from child in grid.Children
                            where Grid.GetRow(child) == 0 && Grid.GetColumn(child) == x
                            select child;

                while (eList.Count() > 0)
                {
                    grid.Children.Remove(eList.First());
                }

                y++;
            }
        }


        //public void Tick1()
        //{
        //    int y = 0;
        //    int x = 0;

        //    if (ColCount == 27)
        //    {
        //        block = false;
        //    }
        //    else if (ColCount == 0)
        //    {
        //        block = true;
        //    }

        //    while (y != 1)
        //    {
        //        grid.Children.Add(new Frame
        //        {
        //            BackgroundColor = Color.AliceBlue,
        //            CornerRadius = 90,
        //            HeightRequest = 20,
        //            WidthRequest = 10,
        //        },
        //        ColCount, 0);

        //        if (block == true)
        //        {
        //            ColCount++;
        //        }
        //        else
        //        {
        //            ColCount--;
        //        }


        //        if (ColCount > -1)
        //        {
        //            if (block == false)
        //                x = ColCount + 4;
        //            else
        //                x = ColCount - 4;
        //            if (x == -3)
        //                x = 3;
        //        }

        //        var eList = from child in grid.Children
        //                    where Grid.GetRow(child) == 0 && Grid.GetColumn(child) == x
        //                    select child;

        //        while (eList.Count() > 0)
        //        {
        //            grid.Children.Remove(eList.First());
        //        }

        //        y++;
        //    }
        //}

        //public void Tick2()
        //{
        //    int y = 0;
        //    int x = 0;

        //    if (ColCount == 30)
        //    {
        //        ColCount = 0;
        //    }

        //    while (y != 1)
        //    {
        //        grid.Children.Add(new Frame
        //        {
        //            BackgroundColor = Color.AliceBlue,
        //            CornerRadius = 90,
        //            HeightRequest = 20,
        //            WidthRequest = 10,
        //        },
        //        ColCount, 0);

        //        ColCount++;

        //        x = ColCount - 4;

        //        var eList = from child in grid.Children
        //                    where Grid.GetRow(child) == 0 && Grid.GetColumn(child) == x
        //                    select child;

        //        while (eList.Count() > 0)
        //        {
        //            grid.Children.Remove(eList.First());
        //        }

        //        y++;
        //    }
        //}

        //public void Tick3()
        //{
        //    int y = 0;
        //    int x = 0;

        //    if (ColCount == 0)
        //    {
        //        ColCount = 30;
        //    }

        //    while (y != 1)
        //    {
        //        grid.Children.Add(new Frame
        //        {
        //            BackgroundColor = Color.AliceBlue,
        //            CornerRadius = 90,
        //            HeightRequest = 20,
        //            WidthRequest = 10,
        //        },
        //        ColCount, 0);

        //        ColCount--;
                
        //        x = ColCount + 4;

        //        if (x >= 30)
        //            x = x - 29;

        //        var eList = from child in grid.Children
        //                    where Grid.GetRow(child) == 0 && Grid.GetColumn(child) == x
        //                    select child;

        //        while (eList.Count() > 0)
        //        {
        //            grid.Children.Remove(eList.First());
        //        }

        //        y++;
        //    }
        //}
    }
}