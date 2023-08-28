using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace bankomat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Admin : Page
    {
        
        public Admin()
        {
            this.InitializeComponent();
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            maszyna.Text = "Liczba banknotów w maszynie:\n";
            dziesiec.Text = "Banknot 10: sztuk " + Wydawanie.ilosc_banknotow[0].ToString();
            dwadziescia.Text = "Banknot 20: sztuk " + Wydawanie.ilosc_banknotow[1].ToString();
            piedziesiat.Text = "Banknot 50: sztuk " + Wydawanie.ilosc_banknotow[2].ToString();
            sto.Text = "Banknot 100: sztuk " + Wydawanie.ilosc_banknotow[3].ToString();
            dwiescie.Text = "Banknot 200: sztuk "+ Wydawanie.ilosc_banknotow[4].ToString();
            piecset.Text = "Banknot 500: sztuk "+ Wydawanie.ilosc_banknotow[5].ToString();
            loger.Text = $"Wydane banknoty:\n10zł sztuk: {Wydawanie.log[0]}\n20zł sztuk: {Wydawanie.log[1]}\n" +
                $"50zł sztuk: {Wydawanie.log[2]}\n100zł sztuk: {Wydawanie.log[3]}\n200zł sztuk: {Wydawanie.log[4]}\n" +
                $"500zł sztuk: {Wydawanie.log[5]}";
        }
        private async Task<int> InputTextDialogAsync(string title)
        {
            TextBox inputTextBox = new TextBox();
            inputTextBox.AcceptsReturn = false;
            inputTextBox.Height = 32;
            ContentDialog dialog = new ContentDialog();
            dialog.Content = inputTextBox;
            dialog.Title = title;
            dialog.IsSecondaryButtonEnabled = true;
            dialog.PrimaryButtonText = "Ok";
            dialog.SecondaryButtonText = "Cancel";
            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
                return Convert.ToInt32(inputTextBox.Text);
            return 0;
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            
            if(sender.GetHashCode().Equals(dziesiec_zmiana.GetHashCode()))
            {
                Wydawanie.ilosc_banknotow[0] = await InputTextDialogAsync("Podaj liczbe");
                dziesiec.Text = "Banknot 10: sztuk " + Wydawanie.ilosc_banknotow[0].ToString();
            }
            else if (sender.GetHashCode().Equals(dwadziescia_zmiana.GetHashCode()))
            {
                Wydawanie.ilosc_banknotow[1] = await InputTextDialogAsync("Podaj liczbe");
                dwadziescia.Text = "Banknot 20: sztuk " + Wydawanie.ilosc_banknotow[1].ToString();
            }
            else if (sender.GetHashCode().Equals(piedziesiat_zmiana.GetHashCode()))
            {
                Wydawanie.ilosc_banknotow[2] = await InputTextDialogAsync("Podaj liczbe");
                piedziesiat.Text = "Banknot 50: sztuk " + Wydawanie.ilosc_banknotow[2].ToString();
            }
            else if (sender.GetHashCode().Equals(sto_zmiana.GetHashCode()))
            {
                Wydawanie.ilosc_banknotow[3] = await InputTextDialogAsync("Podaj liczbe");
                sto.Text = "Banknot 100: sztuk " + Wydawanie.ilosc_banknotow[3].ToString();
            }
            else if (sender.GetHashCode().Equals(dwiescie_zmiana.GetHashCode()))
            {
                Wydawanie.ilosc_banknotow[4] = await InputTextDialogAsync("Podaj liczbe");
                dwiescie.Text = "Banknot 200: sztuk " + Wydawanie.ilosc_banknotow[4].ToString();
            }
            else if (sender.GetHashCode().Equals(piecset_zmiana.GetHashCode()))
            {
                Wydawanie.ilosc_banknotow[5] = await InputTextDialogAsync("Podaj liczbe");
                piecset.Text = "Banknot 500: sztuk " + Wydawanie.ilosc_banknotow[5].ToString();
            }
        }

       

        private void dziesiec_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }
    }
}
