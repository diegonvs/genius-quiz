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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Projeto
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string estado = "normal";
        string opcao1;
        string opcao2;
        string opcao3;
        string rodada = "1";
        List<string> parametros = new List<string>();
        
        
        public MainPage()
        {
           
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
            if ((string)e.Parameter.ToString() == "reiniciar")
            {
                this.parametros = new List<string>();
            }
                
                estado = (string)e.Parameter.ToString();
                parametros.Add(estado);
                parametros.Add(rodada);
                
                                
                  
        }

        private void Enviar_Click(object sender, RoutedEventArgs e)
        {
            Portugues.Visibility = Visibility.Visible;


            Frame.Navigate(typeof(JogoSequencia), parametros);
            

        }

        private void Portugues_Click(object sender, RoutedEventArgs e)
        {
            opcao1 = "P";
            parametros.Add(opcao1);

        }

        private void Matematica_Click(object sender, RoutedEventArgs e)
        {
            opcao2 = "M";
            parametros.Add(opcao2);
        }

        private void Variedades_Click(object sender, RoutedEventArgs e)
        {
            opcao3 = "V";
            parametros.Add(opcao3);
        }
    }
}
