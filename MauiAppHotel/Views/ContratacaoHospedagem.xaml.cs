namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

	public ContratacaoHospedagem()
	{
		InitializeComponent();
         
        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtppck_checkin.MinimumDate = DateTime.Now;
        dtppck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtppck_checkout.MinimumDate = dtppck_checkin.Date.AddDays(1);
        dtppck_checkout.MaximumDate = dtppck_checkin.Date.AddMonths(6);

    }

    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new HospedagemContratada());
        }
        catch (Exception ex) 
        {
            DisplayAlert("Ops", ex.Message, "ok");
        }
    }

    private void dtppck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_chackin = elemento.Date;

        dtppck_checkout.MinimumDate = data_selecionada_chackin.AddDays(1);
        dtppck_checkout.MaximumDate = data_selecionada_chackin.AddMonths(6);

    }
}