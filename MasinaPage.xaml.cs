using Medii_Mobile_App_Cadis_Voicila.Models;
    
namespace Medii_Mobile_App_Cadis_Voicila;

public partial class MasinaPage : ContentPage

	{
    Inchiriere sl;
    public MasinaPage(Inchiriere slist)
    {
        InitializeComponent();
        sl = slist;
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Masina p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Masina;
            var lp = new ListMasina()
            {
                InchiriereID = sl.ID,
                MasinaID = p.ID
            };
            await App.Database.SaveListMasinaAsync(lp);
            p.ListMasini = new List<ListMasina> { lp };
            await Navigation.PopAsync();
        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var masina = (Masina)BindingContext;
        await App.Database.SaveMasinaAsync(masina);
        listView.ItemsSource = await App.Database.GetMasiniAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var masina = (Masina)BindingContext;
        await App.Database.DeleteMasinaAsync(masina);
        listView.ItemsSource = await App.Database.GetMasiniAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMasiniAsync();
    }

}