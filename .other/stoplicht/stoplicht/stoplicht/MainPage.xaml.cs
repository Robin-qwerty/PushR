using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace stoplicht
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            color.BackgroundColor = Color.Black;

        }

        public void stoplicht()
        {
            List<SchemaModel> list = new List<SchemaModel>
            {
                new SchemaModel
                {
                    time= 12,
                    color = "red"
                },
                new SchemaModel
                {
                    time= 6,
                    color = "green"
                },
                new SchemaModel
                {
                    time= 6,
                    color = "orange"
                }
            };


        }

        
    }
}
