using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Proyecto_Final
{
    public partial class FichaWindow : Window
    {
        public string Nombre { get; set; }
        public string Definicion { get; set; }
        public string FuenteDefinicion { get; set; }
        public string Comentario { get; set; }
        public Registro Registro { get; set; }
        public CategoriaGramatical CategoriaGramatical { get; set; }
        public Idioma Idioma { get; set; }
        public ObservableCollection<Idioma> ListaIdiomas { get; set; }
        public string Imagen { get; set; }
        public FichaWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
