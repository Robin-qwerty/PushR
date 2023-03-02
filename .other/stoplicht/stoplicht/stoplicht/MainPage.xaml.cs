using System;
using System.Collections.Generic;
using System.Threading;
using Xamarin.Forms;
using Color = Xamarin.Forms.Color;

namespace stoplicht
{
    public partial class MainPage : ContentPage
    {
        List<string> Colors;
        List<SchemaModel> Procedure;
        int Count;

        public MainPage()
        {
            InitializeComponent();

            MakeColors();
            Schema();

            Count= 0;

            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                Tick();

                return true; // return true to repeat counting, false to stop timer
            });
        }

        void Schema()
        {
            Procedure = new List<SchemaModel>
            {
                new SchemaModel
                {
                    Red = Colors[3],
                    Orange = Colors[1],
                    Green = Colors[2]
                },
                new SchemaModel
                {
                    Red = Colors[3],
                    Orange = Colors[1],
                    Green = Colors[2]
                },
                new SchemaModel
                {
                    Red = Colors[0],
                    Orange = Colors[1],
                    Green = Colors[5]
                },
                new SchemaModel
                {
                    Red = Colors[0],
                    Orange = Colors[4],
                    Green = Colors[2]
                },
            };
        }

        void MakeColors()
        {
            Colors = new List<string>
            {
                "#800000", //LR
                "#5e2f08", //LO
                "#0f3d0f", //LG
                "#ff0000", //DR
                "#ec7513", //DO
                "#33cc33"  //DG
            };
        }

        void Tick()
        {
            var s = Procedure[Count];

            red.BackgroundColor = Color.FromHex(s.Red);
            orange.BackgroundColor = Color.FromHex(s.Orange);
            green.BackgroundColor = Color.FromHex(s.Green);

            Count++;
            if (Count == 4) 
            {
                Count = 0;
            }
        }
    }
}
