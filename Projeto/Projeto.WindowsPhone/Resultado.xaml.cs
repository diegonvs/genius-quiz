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
using System.Threading;
using Windows.Storage;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Projeto
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Resultado : Page
    {
        StorageFolder folder = ApplicationData.Current.LocalFolder;
        StorageFolder folderTemp = ApplicationData.Current.TemporaryFolder;
        ApplicationDataContainer local = ApplicationData.Current.LocalSettings;
        public Resultado()
        {
            this.InitializeComponent();


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Criar.IsEnabled = true;
            resposta.Text = e.Parameter.ToString();

        }

        private void ok2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));

        }
        public async void AdicionarRanking()
        {

            StorageFile file = await folder.CreateFileAsync("ranking.txt", CreationCollisionOption.OpenIfExists);

            string player = NomePlayer.Text + "/" + local.Values["rodada"].ToString() + "/" + "@";
            if (NomePlayer.Text != "")
            {

                await FileIO.AppendTextAsync(file, player);

                OrganizarPontuacao();
            }

        }

        private void Criar_Click(object sender, RoutedEventArgs e)
        {
            Criar.IsEnabled = false;
            AdicionarRanking();
            
        }

        public async void OrganizarPontuacao()
        {
            List<Jogador> listaPlayers = new List<Jogador>();
            List<Jogador> listaResultado = new List<Jogador>();
            StorageFile fileTemp = await folderTemp.CreateFileAsync("rankingTemp.txt", CreationCollisionOption.OpenIfExists);
            StorageFile file = await folder.GetFileAsync("ranking.txt");
            string ranking = await FileIO.ReadTextAsync(file);
            var rankingDividido = ranking.Split('@');
            foreach (var item in rankingDividido)
            {
                var informaçaoDividida = item.Split('/');
                if (informaçaoDividida.ElementAt(0) != "")
                {
                    listaPlayers.Add(new Jogador(informaçaoDividida.ElementAt(0), Convert.ToInt32(informaçaoDividida.ElementAt(1))));
                }


            }
            listaResultado = listaPlayers.OrderByDescending(x => x.Rodada).ToList();

            for (int i = 0; i < listaResultado.Count; i++)
            {
                Jogador playerTemp = listaResultado.ElementAt(i);

                await FileIO.AppendTextAsync(fileTemp, playerTemp.Nome + "/" + playerTemp.Rodada.ToString() + "/" + "@");


            }
            await FileIO.WriteTextAsync(file, await FileIO.ReadTextAsync(fileTemp));

            await fileTemp.DeleteAsync();

        }

    }
}
