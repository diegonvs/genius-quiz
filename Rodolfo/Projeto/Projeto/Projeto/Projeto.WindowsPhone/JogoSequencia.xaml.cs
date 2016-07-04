using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class JogoSequencia : Page
    {
        string estado;
        List<string> parametros = new List<string>();
        int rodada = -1;
        int vez = -1;
        List<string> lista = new List<string>();
        List<string> listaTapped = new List<string>();
        List<string> listaAux = new List<string>();




        public JogoSequencia()
        {
            listaAux.Add("00");
            listaAux.Add("10");
            listaAux.Add("01");
            listaAux.Add("11");
            lista = listaAux;

            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            parametros = (List<string>)e.Parameter;
            rodada = Convert.ToInt32(parametros.ElementAt(1));
            if (parametros.Contains("reiniciar"))
            {

                this.estado = "reiniciar";
                this.vez = -1;
                this.rodada = 1;
                CriaListaAleatoria();
                this.estado = "normal";
            }
            else
            {
                CriaListaAleatoria();
            }

           
            
        }


        public void CriaListaAleatoria()
        {
            if (estado == "reiniciar")
            {
                rodada = 1;
                vez = -1;
                listaAux = new List<string>();
                listaAux.Add("00");
                listaAux.Add("10");
                listaAux.Add("01");
                listaAux.Add("11");
                lista = new List<string>();
                lista = listaAux;
            }

            ResultadoSequencia.Text = " ";

            listaTapped = new List<string>();

           
            vez = -1;
            int rodadaAux = rodada -1;
            Random rnd = new Random();

            while (rodadaAux > 0)
            {
                lista.Add(listaAux.ElementAt(rnd.Next(0, listaAux.Count)));
                rodadaAux--;

            }
            for (int i = 0; i < this.lista.Count; i++)
            {
                ResultadoSequencia.Text = ResultadoSequencia.Text + " " + lista.ElementAt(i);

            }
            ResultadoSequencia.Text += " / ";
            estado = "normal";
            //ImprimeNovaRodada();

        }

        private void Stack00_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listaTapped.Count < lista.Count)
            {
                listaTapped.Add("00");
                vez++;
                if (!Verificar())
                {

                    Frame.Navigate(typeof(Resultado), rodada -1);
                }

            }
            if (listaTapped.Count == lista.Count)
            {

                Frame.Navigate(typeof(Questionario), parametros);

            }

        }

        private void Stack10_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listaTapped.Count < lista.Count)
            {
                listaTapped.Add("10");
                vez++;
                if (!Verificar())
                {

                    Frame.Navigate(typeof(Resultado), rodada -1);
                }

            }
            if (listaTapped.Count == lista.Count)
            {

                Frame.Navigate(typeof(Questionario), parametros);

            }
        }

        private void Stack01_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listaTapped.Count < lista.Count)
            {
                listaTapped.Add("01");
                vez++;
                if (!Verificar())
                {

                    Frame.Navigate(typeof(Resultado), rodada -1);
                }

            }
            if (listaTapped.Count == lista.Count)
            {

                Frame.Navigate(typeof(Questionario), parametros);

            }
        }

        private void Stack11_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listaTapped.Count < lista.Count)
            {
                listaTapped.Add("11");
                vez++;
                if (!Verificar())
                {

                    Frame.Navigate(typeof(Resultado), rodada -1);
                }

            }
            if (listaTapped.Count == lista.Count)
            {
                
                Frame.Navigate(typeof(Questionario), parametros);


            }
        }


        public void ImprimeNovaRodada()
        {
            int a = 0;
            int b = 0;
            
            List<string> listaTemp = lista;
            while (listaTemp.Count > 0)
            {
                string QualStack = lista.ElementAt(0);
                if (QualStack == "00")
                {
                    Stack00.Visibility = Visibility.Collapsed;
                    for (int i = 0; i < 1000000; i++)
                    {
                        a = +b*i;
                    }
                    Stack00.Visibility = Visibility.Visible;

                }
                else if (QualStack == "10")
                {
                    Stack10.Visibility = Visibility.Collapsed;
                    for (int i = 0; i < 1000000; i++)
                    {
                       
                        a = +b * i;
                    }
                    Stack10.Visibility = Visibility.Visible;

                }
                else if (QualStack == "01")
                {
                    Stack01.Visibility = Visibility.Collapsed;
                    for (int i = 0; i < 100000; i++)
                    {
                        
                        a = +b * i;
                    }
                    Stack01.Visibility = Visibility.Visible;
                }
                else
                {
                    Stack11.Visibility = Visibility.Collapsed;
                    for (int i = 0; i < 100000; i++)
                    {
                       
                        a = +b * i;
                    }
                    Stack11.Visibility = Visibility.Visible;
                }

                listaTemp.RemoveAt(0);
            }
        }
        public bool Verificar()
        {
            bool aux;

            if (lista.ElementAt(vez) == listaTapped.ElementAt(vez))
            {

                aux = true;
            }
            else
            {
                aux = false;
            }

            return aux;

        }

    }
}
