using Medii_Mobile_App_Cadis_Voicila.Models;

namespace Medii_Mobile_App_Cadis_Voicila;

public partial class InchirierePage : ContentPage
{
	public InchirierePage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Inchiriere)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveInchiriereAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Inchiriere)BindingContext;
        await App.Database.DeleteInchiriereAsync(slist);
        await Navigation.PopAsync();
    }
}