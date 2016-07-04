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

    public sealed partial class Questionario : Page
    {
        Windows.Storage.ApplicationDataContainer local = Windows.Storage.ApplicationData.Current.LocalSettings;

        List<Questao> questoes = new List<Questao>();
        BancoQuestoes banco = new BancoQuestoes();

        string resultado;
        List<int> listaUsadosAux = new List<int>();

        Random rnd = new Random();
        string certa = "";
        int rodada;


        public Questionario()
        {


            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            rodada = (int)local.Values["rodada"];
            questoes = (List<Questao>)e.Parameter;



            QuestoesAleatorias();

        }
        public void QuestoesAleatorias()
        {

            int indice = IndiceAleatorio();
            Rodada.Text = "Rodada " + rodada;
            Questao questao = questoes.ElementAt(indice);
            Pergunta.Text = questao.Pergunta;
            Opcao1.Content = questao.RespostaCerta;
            Opcao2.Content = questao.Respostas.ElementAt(1);
            Opcao3.Content = questao.Respostas.ElementAt(2);
            certa = questao.RespostaCerta;
        }
        public int IndiceAleatorio()
        {
            int indice = rnd.Next(0, questoes.Count);
            if (local.Values["indices"].ToString().Contains("-" + indice.ToString()))
            {
                while (local.Values["indices"].ToString().Contains("-" + indice.ToString()))
                {
                    indice = rnd.Next(0, questoes.Count - 1);
                }
            }

            local.Values["indices"] = local.Values["indices"].ToString() + "-" + indice.ToString();

            return indice;

        }
        public void VerificarResposta(string resposta)
        {

            if (resposta == certa)
            {
                if (rodada == questoes.Count)
                {

                    resultado = ("Você acertou!! Completou as: " + rodada.ToString() + " rodadas");
                    Frame.Navigate(typeof(Resultado), resultado);
                }
                else
                {
                    rodada += 1;
                    local.Values["rodada"] = rodada;
                    Frame.Navigate(typeof(JogoSequencia), questoes);

                }

            }
            else
            {
                resultado = "Você errou a questao na rodada: " + rodada.ToString();
                Frame.Navigate(typeof(Resultado), resultado);
            }

        }

        private void Opcao1_Tapped(object sender, TappedRoutedEventArgs e)
        {

            VerificarResposta(Opcao1.Content.ToString());

        }

        private void Opcao2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            VerificarResposta(Opcao2.Content.ToString());
        }

        private void Opcao3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            VerificarResposta(Opcao3.Content.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rodada == questoes.Count)
            {

                resultado = ("Você acertou!! Completou as: " + rodada.ToString() + " rodadas");
                Frame.Navigate(typeof(Resultado), resultado);
            }
            else
            {
                rodada += 1;
                local.Values["rodada"] = rodada;
                Frame.Navigate(typeof(JogoSequencia), questoes);
            }
        }

    }
}
