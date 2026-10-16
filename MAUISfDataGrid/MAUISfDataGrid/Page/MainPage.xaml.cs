using MAUISfDataGrid.Pages;

namespace MAUISfDataGrid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DataGridPage(10000));
        }
    }
}
