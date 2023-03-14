using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoadingScreen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomMenu : ContentView
    {
        public BottomMenu(int TotalButtons, int ColCount)
        {
            InitializeComponent();
            MakeGrid(TotalButtons, ColCount);
        }



        void MakeGrid(int TotalButtons, int ColCount)
        {
            Grid grid = new Grid();

            for (int i = 0; i < ColCount; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            int Col = 0;
            int Row = 0;

            for (int i = 0; i < TotalButtons; i++)
            {
                if ((TotalButtons % ColCount) == 0)
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(45) });
                }

                Button button = new Button
                {
                    Text = i.ToString(),
                    FontSize = 15
                };
                button.Clicked += (sender, args) =>
                {
                };

                grid.Children.Add(button, Col, Row);

                Col++;
                if (Col == ColCount)
                {
                    Row++;

                    Col = 0;
                }
            }

            Content = grid;
        }

    }
}