using Medii_Mobile_App_Cadis_Voicila.Models;

namespace Medii_Mobile_App_Cadis_Voicila;

public partial class InchiriereEntryPage : ContentPage
{
	public InchiriereEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetInchiriereListAsync();
    }
    async void OnInchiriereAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InchirierePage
        {
            BindingContext = new Inchiriere()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new InchirierePage
            {
                BindingContext = e.SelectedItem as Inchiriere
            });
        }
    }
}