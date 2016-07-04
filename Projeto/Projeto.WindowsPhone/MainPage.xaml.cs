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
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Projeto
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Questao> questoes = new List<Questao>();

        ApplicationDataContainer local = ApplicationData.Current.LocalSettings;

        public MainPage()
        {

            this.InitializeComponent();


            this.NavigationCacheMode = NavigationCacheMode.Required;

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            menu.Visibility = Visibility.Visible;
            menu.IsTapEnabled = true;
            selecionaPergunta.Visibility = Visibility.Collapsed;
            selecionaPergunta.IsTapEnabled = false;
            Portugues.IsChecked = false;
            Matematica.IsChecked = false;
            Variedades.IsChecked = false;
            Portugues.IsEnabled = true;
            Matematica.IsEnabled = true;
            Variedades.IsEnabled = true;
            local.Values["rodada"] = 1;
            local.Values["opcao"] = " ";
            local.Values["indices"] = null;

        }


        private async void Enviar_Click(object sender, RoutedEventArgs e)
        {
            local.Values["rodada"] = 1;
            local.Values["indices"] = " ";
            if (local.Values["opcao"].ToString() == " ")
            {
                Alerta.Text = "Você tem que escolher uma matéria!";
                await Task.Delay(TimeSpan.FromSeconds(3));
                Alerta.Text = "";

            }
            else
            {
                questoes = QuestionarioSelecionado();
                Frame.Navigate(typeof(JogoSequencia), questoes);
            }

        }

        private void Portugues_Click(object sender, RoutedEventArgs e)
        {
            local.Values["opcao"] += "P";
            Portugues.IsEnabled = false;
        }

        private void Matematica_Click(object sender, RoutedEventArgs e)
        {
            local.Values["opcao"] += "M";
            Matematica.IsEnabled = false;
            
        }

        private void Variedades_Click(object sender, RoutedEventArgs e)
        {
            local.Values["opcao"] += "V";
            Variedades.IsEnabled = false;

        }
        public List<Questao> QuestionarioSelecionado()
        {

            BancoQuestoes banco = new BancoQuestoes();
            string opcoes = local.Values["opcao"].ToString();

            List<Questao> questoes = new List<Questao>();
            if (opcoes.Contains("P"))
            {
                foreach (var item in banco.QuestoesP)
                {
                    questoes.Add(item);
                }
            }
            if (opcoes.Contains("M"))
            {
                foreach (var item in banco.QuestoesM)
                {
                    questoes.Add(item);
                }
            }
            if (opcoes.Contains("V"))
            {
                foreach (var item in banco.QuestoesV)
                {
                    questoes.Add(item);
                }
            }

            return questoes;
        }

        private void ranking_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Ranking));
        }
        private void prei_Click(object sender, RoutedEventArgs e)
        {
            
            menu.Visibility = Visibility.Collapsed;            
            selecionaPergunta.Visibility = Visibility.Visible;
            menu.IsTapEnabled = false;
            selecionaPergunta.IsTapEnabled = true;
        }
        private void como_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(comoJogar));
        }
        private void sobre_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(sobre));
        }

    }
}
