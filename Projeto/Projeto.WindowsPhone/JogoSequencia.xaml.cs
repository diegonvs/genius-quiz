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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556
namespace Projeto
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class JogoSequencia : Page
    {
        Windows.Storage.ApplicationDataContainer local = Windows.Storage.ApplicationData.Current.LocalSettings;

        int rodada;
        int vez = -1;
        List<string> lista = new List<string>();
        List<string> listaTapped = new List<string>();
        List<string> listaAux = new List<string>();
        List<Questao> questoesAux = new List<Questao>();




        public JogoSequencia()
        {


            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            rodada = (int)local.Values["rodada"];
            questoesAux = (List<Questao>)e.Parameter;


            CriaListaAleatoria();



        }


        public void CriaListaAleatoria()
        {
            if (rodada == 1)
            {


                listaAux = new List<string>();
                listaAux.Add("00");
                listaAux.Add("10");
                listaAux.Add("01");
                listaAux.Add("11");
                lista = new List<string>();
                lista = listaAux;
            }
            vez = -1;
            //ResultadoSequencia.Text = " ";

            listaTapped = new List<string>();



            int rodadaAux;
            Random rnd = new Random();
            if (rodada == 1)
            {
                rodadaAux = rodada - 1;
            }
            else
            {
                rodadaAux = 1;
            }

            while (rodadaAux > 0)
            {
                lista.Add(listaAux.ElementAt(rnd.Next(0, listaAux.Count)));
                rodadaAux--;

            }
            //for (int i = 0; i < this.lista.Count; i++)
            //{
            //    ResultadoSequencia.Text = ResultadoSequencia.Text + " " + lista.ElementAt(i);

            //}
            //ResultadoSequencia.Text += " / ";


            Jogo.IsTapEnabled = false;
            ImprimeNovaRodada(lista);
            Jogo.IsTapEnabled = true;


        }

        private void Stack00_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listaTapped.Count < lista.Count)
            {
                listaTapped.Add("00");
                vez++;
                Verificar();
            }
            if (listaTapped.Count == lista.Count)
            {


                Frame.Navigate(typeof(Questionario), questoesAux);

            }

        }

        private void Stack10_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listaTapped.Count < lista.Count)
            {
                listaTapped.Add("10");
                vez++;
                Verificar();

            }
            if (listaTapped.Count == lista.Count)
            {

                Frame.Navigate(typeof(Questionario), questoesAux);

            }
        }

        private void Stack01_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listaTapped.Count < lista.Count)
            {
                listaTapped.Add("01");
                vez++;
                Verificar();

            }
            if (listaTapped.Count == lista.Count)
            {
                ;
                Frame.Navigate(typeof(Questionario), questoesAux);

            }
        }

        private void Stack11_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listaTapped.Count < lista.Count)
            {
                listaTapped.Add("11");
                vez++;
                Verificar();

            }
            if (listaTapped.Count == lista.Count)
            {


                Frame.Navigate(typeof(Questionario), questoesAux);


            }
        }


        public async void ImprimeNovaRodada(List<string> lista)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(900));
            List<string> listaTemp = new List<string>();
            foreach (var item in this.lista)
            {
                listaTemp.Add(item);
            }
            foreach (var item in listaTemp)
            {
                string QualStack = item;
                if (QualStack == "00")
                {

                    await Task.Delay(TimeSpan.FromMilliseconds(700));
                    Stack00.Opacity = 1;
                    await Task.Delay(TimeSpan.FromMilliseconds(200));
                    Stack00.Opacity = 0.4;

                }
                if (QualStack == "10")
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(700));
                    Stack10.Opacity = 1;
                    await Task.Delay(TimeSpan.FromMilliseconds(200));
                    Stack10.Opacity = 0.4;

                }
                if (QualStack == "01")
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(700));
                    Stack01.Opacity = 1;
                    await Task.Delay(TimeSpan.FromMilliseconds(200));
                    Stack01.Opacity = 0.4;

                }
                if (QualStack == "11")
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(700));
                    Stack11.Opacity = 1;
                    await Task.Delay(TimeSpan.FromMilliseconds(200));
                    Stack11.Opacity = 0.4;

                }
            }

        }
        public void Verificar()
        {


            if (lista.ElementAt(vez) != listaTapped.ElementAt(vez))
            {
                string resultado = "Você errou a sequencia na rodada: " + rodada.ToString();
                Frame.Navigate(typeof(Resultado), resultado);
            }


        }

    }

}
