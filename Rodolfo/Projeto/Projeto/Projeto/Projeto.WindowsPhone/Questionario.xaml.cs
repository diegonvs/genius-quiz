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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Projeto
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class Questionario : Page
    {
        string estado = "normal";
        List<string> opcoes = new List<string>();
        BancoQuestoes banco = new BancoQuestoes();
        List<string> parametros = new List<string>();

        List<int> listaUsadosAux = new List<int>();

        Random rnd = new Random();
        string certa = "";
        int rodada;
        

        public Questionario()
        {
           
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            this.parametros = (List<string>)e.Parameter;
            this.parametros.Remove("reiniciar");
            if (parametros.ElementAt(0) != "") 
            {
                this.parametros.Insert(0, "");
            }
            this.rodada = Convert.ToInt32(parametros.ElementAt(1));
            QuestionarioAleatorio(parametros);

        }
        //Criar função que gere aleatoriedade e que não se repita
        public void QuestionarioAleatorio(List<string> opcao)
        {
            List<Questao> questoes = new List<Questao>();
            if (opcao.Contains("P"))
            {
                foreach (var item in banco.QuestoesP)
                {
                    questoes.Add(item);
                }
            }
            if (opcao.Contains("M"))
            {
                foreach (var item in banco.QuestoesM)
                {
                    questoes.Add(item);
                }
            }
            if (opcao.Contains("V"))
            {
                foreach (var item in banco.QuestoesV)
                {
                    questoes.Add(item);
                }
            }

            int aux = rnd.Next(0, questoes.Count);
            Pergunta.Text = questoes.ElementAt(aux).Pergunta;
            Opcao1.Content = questoes.ElementAt(aux).RespostaCerta;
            Opcao2.Content = questoes.ElementAt(aux).Respostas.ElementAt(1);
            Opcao3.Content = questoes.ElementAt(aux).Respostas.ElementAt(2);
            certa = questoes.ElementAt(aux).RespostaCerta;
            auxiliar.Text = rodada.ToString();
        }

        public void VerificarResposta(string resposta)
        {

            if (resposta == certa)
            {

                this.parametros.RemoveAt(1);
                parametros.Insert(1, (rodada+1).ToString());
                Frame.Navigate(typeof(JogoSequencia), parametros );

            }
            else
            {
                Frame.Navigate(typeof(Resultado), rodada);
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
        public void VerificarSeAcabou()
        {
            



        }

    }
}
