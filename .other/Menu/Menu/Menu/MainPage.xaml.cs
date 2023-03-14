using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{

		public MainPage ()
		{
			InitializeComponent ();
			
			Menu menu = new Menu (7, 3);
			TopMenu topMenu = new TopMenu ();

			topMenu.SetTitle("Hello world!");

			bottom.Children.Add(menu);
			top.Children.Add(topMenu);
		}
	}
}