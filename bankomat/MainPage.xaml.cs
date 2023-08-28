using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Perception;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace bankomat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        int kwota;

        public MainPage()
        {
            this.InitializeComponent();
                                   
        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Admin));
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            var kasa = Convert.ToInt32(wplata.Text);
            if(kasa%10 != 0)
            {
                wydano.Text = "Podano niewspieraną kwotę";
            }
            else if (Wydawanie.Suma() < kasa)
            {
                wydano.Text = "Podano zbyt wielką kwotę";
            }
            else
            {
                
                int[] reszka;
                int[] banknoty = { 0,0,0,0,0,0};

                for (int i = 0; i < Wydawanie.ilosc_banknotow.Length; i++)
                {
                    banknoty[i] = Wydawanie.ilosc_banknotow[i];
                    if (Wydawanie.ilosc_banknotow[i] <= 2)
                    {
                        Wydawanie.ilosc_banknotow[i] = 0;
                    }

                }
                var k = Wydawanie.Dynamic(kasa, Wydawanie.banknoty, Wydawanie.ilosc_banknotow, out reszka);
                if(k is null)
                {
                    Wydawanie.ilosc_banknotow = banknoty;
                    k = Wydawanie.Dynamic(kasa, Wydawanie.banknoty, Wydawanie.ilosc_banknotow, out reszka);
                }
                string slowo = "Wydano\n";
                if (k != null)
                {
                    for (int i = 0; i < reszka.Length; i++)
                    {
                        
                        if (reszka[i] > 0)
                        {

                            slowo += Wydawanie.banknoty[i].ToString() + "zł";
                            slowo += ": ";
                            slowo += "sztuk " + reszka[i].ToString();
                            slowo += "\n";
                            banknoty[i] -= reszka[i];
                            Wydawanie.log[i] += reszka[i];
                            
                        }

                    }
                }
                else
                {
                    slowo = "Nie ma środków na tyle aby wydać";
                }
                
                wydano.Text = slowo;
                Wydawanie.ilosc_banknotow = banknoty;
                Debug.WriteLine(Wydawanie.ilosc_banknotow);
            }
        }
    }
}
