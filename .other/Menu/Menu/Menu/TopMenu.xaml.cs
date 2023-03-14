using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopMenu : ContentView
	{
		public TopMenu ()
		{
			InitializeComponent ();
		}

		public void SetTitle(string title)
		{
			lab.Text = title;
		}
	}
}