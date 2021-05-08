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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_Final
{
    public partial class MainWindow : Window
    {
        private MainWindowVM _mainWindowVM;
        public MainWindow()
        {
            InitializeComponent();
            _mainWindowVM = new MainWindowVM();
            this.DataContext = _mainWindowVM;
        }

        private void buscadorTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
            ((TextBox)sender).Foreground = Brushes.Black;
        }

        private void buscadorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "buscar";
                ((TextBox)sender).Foreground = Brushes.LightGray;
            }
        }

        private void CommandBinding_Executed_AddTerm(object sender, ExecutedRoutedEventArgs e)
        {
            _mainWindowVM.AñadirTermino();
        }
        private void CommandBinding_CanExecute_AddTerm(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_mainWindowVM != null) e.CanExecute = true;
            else e.CanExecute = false;
        }
        private void CommandBinding_Executed_DeleteTerm(object sender, ExecutedRoutedEventArgs e)
        {
            _mainWindowVM.EliminarTermino();
        }
        private void CommandBinding_CanExecute_DeleteTerm(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_mainWindowVM != null && _mainWindowVM.TerminoSeleccionado != null) e.CanExecute = true;
            else e.CanExecute = false;
        }
        private void CommandBinding_Executed_Add(object sender, ExecutedRoutedEventArgs e)
        {
            FichaWindow fichaWindow = new FichaWindow();
            fichaWindow.Owner = this;
            fichaWindow.ListaIdiomas = _mainWindowVM.Idiomas;
            fichaWindow.Imagen = _mainWindowVM.TerminoSeleccionado.Imagen;

            if (fichaWindow.ShowDialog() == true)
            {
                _mainWindowVM.NuevaFicha = new Ficha();
                _mainWindowVM.NuevaFicha.IdFicha = _mainWindowVM.Fichas.Count + 1;
                _mainWindowVM.NuevaFicha.IdTermino = _mainWindowVM.TerminoSeleccionado.IdTermino;
                _mainWindowVM.NuevaFicha.Nombre = fichaWindow.Nombre;
                _mainWindowVM.NuevaFicha.Definicion = fichaWindow.Definicion;
                _mainWindowVM.NuevaFicha.FuenteDefinicion = fichaWindow.FuenteDefinicion;
                _mainWindowVM.NuevaFicha.Comentario = fichaWindow.Comentario;
                _mainWindowVM.NuevaFicha.Registro = fichaWindow.Registro;
                _mainWindowVM.NuevaFicha.CategoriaGramatical = fichaWindow.CategoriaGramatical;
                _mainWindowVM.NuevaFicha.IdIdioma = fichaWindow.Idioma.IdIdioma;
                _mainWindowVM.TerminoSeleccionado.Imagen = fichaWindow.Imagen;
                _mainWindowVM.AñadirFicha();
            }
        }
        private void CommandBinding_CanExecute_Add(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_mainWindowVM != null && _mainWindowVM.TerminoSeleccionado != null) e.CanExecute = true;
            else e.CanExecute = false;
        }
        private void CommandBinding_Executed_Edit(object sender, ExecutedRoutedEventArgs e)
        {
            FichaWindow fichaWindow = new FichaWindow();
            fichaWindow.Owner = this;

            fichaWindow.ListaIdiomas = _mainWindowVM.Idiomas;
            fichaWindow.Nombre = _mainWindowVM.FichaSeleccionada.Nombre;
            fichaWindow.Definicion = _mainWindowVM.FichaSeleccionada.Definicion;
            fichaWindow.FuenteDefinicion = _mainWindowVM.FichaSeleccionada.FuenteDefinicion;
            fichaWindow.Comentario = _mainWindowVM.FichaSeleccionada.Comentario;
            fichaWindow.Registro = _mainWindowVM.FichaSeleccionada.Registro;
            fichaWindow.CategoriaGramatical = _mainWindowVM.FichaSeleccionada.CategoriaGramatical;
            fichaWindow.Idioma.IdIdioma = _mainWindowVM.FichaSeleccionada.IdIdioma;
            if (fichaWindow.ShowDialog() == true)
            {
                _mainWindowVM.FichaSeleccionada.IdTermino = _mainWindowVM.TerminoSeleccionado.IdTermino;
                _mainWindowVM.FichaSeleccionada.Nombre = fichaWindow.Nombre;
                _mainWindowVM.FichaSeleccionada.Definicion = fichaWindow.Definicion;
                _mainWindowVM.FichaSeleccionada.FuenteDefinicion = fichaWindow.FuenteDefinicion;
                _mainWindowVM.FichaSeleccionada.Comentario = fichaWindow.Comentario;
                _mainWindowVM.FichaSeleccionada.Registro = fichaWindow.Registro;
                _mainWindowVM.FichaSeleccionada.CategoriaGramatical = fichaWindow.CategoriaGramatical;
                _mainWindowVM.FichaSeleccionada.IdIdioma = fichaWindow.Idioma.IdIdioma;
                _mainWindowVM.EditarFicha();
            }
        }
        private void CommandBinding_CanExecute_Edit(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_mainWindowVM != null && _mainWindowVM.FichaSeleccionada != null) e.CanExecute = true;
            else e.CanExecute = false;
        }
        private void CommandBinding_Executed_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            _mainWindowVM.EliminarFicha();
        }
        private void CommandBinding_CanExecute_Delete(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_mainWindowVM != null && _mainWindowVM.FichaSeleccionada != null) e.CanExecute = true;
            else e.CanExecute = false;
        }
        private void CommandBinding_Executed_AddDataBase(object sender, ExecutedRoutedEventArgs e)
        {
            NuevaBBDDWindows nuevaBBDD = new NuevaBBDDWindows();
            nuevaBBDD.Owner = this;

            if (nuevaBBDD.ShowDialog() == true)
            {
                Diccionario bd = new Diccionario(_mainWindowVM.BBDDS.Count + 1,nuevaBBDD.NombreBBDD);
                _mainWindowVM.AñadirBBDD(bd);
                Actualizar();
            }
        }
        private void CommandBinding_Executed_LoadDataBase(object sender, ExecutedRoutedEventArgs e)
        {
            CargarDiccionario cargarDiccionario = new CargarDiccionario();
            cargarDiccionario.Owner = this;
            cargarDiccionario.Diccionarios = _mainWindowVM.BBDDS;

            if(cargarDiccionario.ShowDialog() == true)
            {
                DiccionarioSingleton.GetInstance()._diccionario = cargarDiccionario.BBDD;
                Actualizar();
            }
        }
        private void CommandBinding_Executed_Exit(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        private void CommandBinding_Executed_Help(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void Actualizar()
        {
            _mainWindowVM = new MainWindowVM();
            DataContext = _mainWindowVM;
        }
    }
}
