using MauiAppHotel.Models;

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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,

                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),

                DataCheckIn = dtppck_checkin.Date,
                DataCheckOut = dtppck_checkout.Date,

            };

           await Navigation.PushAsync(new HospedagemContratada() 
           {
               BindingContext = h
           });

        }
        catch (Exception ex) 
        {
           await DisplayAlert("Ops", ex.Message, "ok");
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