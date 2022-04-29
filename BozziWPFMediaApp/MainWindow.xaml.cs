using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BozziWPFMediaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int dimensione = 5;
        int somma = 0;
        int contatore = 0;
        int[] valori = new int[dimensione];

        public MainWindow()
        {
            InitializeComponent();
        }

        // gestore dell'evento click sul bottone
        private void BtnSalvaValore_Click(object sender, RoutedEventArgs e)
        {
            int valore = 0;
            bool errore = false;
            // input dei un valore
            string valoreStr = TxtValore.Text;
            // validazione dell'input
            if (valoreStr == "")
            {
                errore = true;
                MessageBox.Show("Errore il valore non può essere vuoto");
            }
            else
            {
                bool conversioneRiuscita = int.TryParse(valoreStr, out valore);
                if (!conversioneRiuscita)
                {
                    errore = true;
                    MessageBox.Show("Errore il valore non è numerico");
                }
            }
            if (contatore >= dimensione)
            {
                errore = true;
                MessageBox.Show("Il numero massimo di valori è stato raggiunto");
            }
            if (!errore)
            {
                valori[contatore] = valore;
                contatore++;
                TxtValore.Text = "";
                BlkValori.Text = BlkValori.Text + "\n" + valore.ToString();
            }
        }

        private void BtnCalcolaMedia_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0; i<contatore; i++)
            {
                somma = somma + valori[i];
            }
            decimal media = (decimal)somma / (decimal)contatore;
            LblRisultato.Content = media;
        }

        private void BtnCalcolaMassimo_Click(object sender, RoutedEventArgs e)
        {
            int max = int.MinValue;
            for (int i = 0; i < contatore; i++)
            {
                if (valori[i] > max)
                {
                    max = valori[i];
                }
            }
            LblRisultatoMax.Content = max;
        }
    }
}
