using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Projeto
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ranking : Page
    {
        StorageFolder folder = ApplicationData.Current.LocalFolder;
        List<string> playersRanking = new List<string>();
        public Ranking()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            ListarRanking();

        }
        public async void ListarRanking()
        {


            List<string> lista = new List<string>();
            StorageFile file = await folder.CreateFileAsync("ranking.txt", CreationCollisionOption.OpenIfExists);
            string ranking = await FileIO.ReadTextAsync(file);
            if (ranking != "")
            {
                var jogadoresDivididos = ranking.Split('@');
                int posicao = 0;
                foreach (var item in jogadoresDivididos)
                {
                    var infoDividida = item.Split('/');
                    if (infoDividida.ElementAt(0) != "")
                    {

                        lista.Add((++posicao).ToString() + ". " + infoDividida.ElementAt(0) + " Rodada: " + infoDividida.ElementAt(1));
                    }

                }
            }

            ListaRanking.ItemsSource = lista;

        }


        private void LimparRanking_Click(object sender, RoutedEventArgs e)
        {
            Limpagem();
            List<string> aux = new List<string>();
            aux.Add("Sem dados");
            ListaRanking.ItemsSource = aux;
        }
        public async void Limpagem()
        {
            StorageFile file = await folder.GetFileAsync("ranking.txt");
            await file.DeleteAsync();
            await folder.CreateFileAsync("ranking.txt", CreationCollisionOption.OpenIfExists);

        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }


    }
}