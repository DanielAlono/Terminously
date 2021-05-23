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
    public partial class BorrarDiccionario : Window
    {
        public ObservableCollection<Diccionario> Diccionarios { get; set; }
        public ObservableCollection<Diccionario> DiccionariosBorrados { get; set; }
        public Diccionario Diccionario { get; set; }
        public BorrarDiccionario()
        {
            InitializeComponent();
            DiccionariosBorrados = new ObservableCollection<Diccionario>();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void borrarButton_Click(object sender, RoutedEventArgs e)
        {
            if(Diccionario != null)
            {
                DiccionariosBorrados.Add(Diccionario);
                Diccionarios.Remove(Diccionario);
            }
        }
    }
}
