using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Forms;
using System.IO;
using System;
using System.Diagnostics;

namespace Proyecto_Final
{
    public partial class MainWindow : Window
    {
        private MainWindowVM _mainWindowVM;
        public MainWindow()
        {
            _mainWindowVM = new MainWindowVM();
            InitializeComponent();
            DataContext = _mainWindowVM;
        }
        private void buscadorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Comprobamos que nuestro DataContext y que los Terminos recogidos por el diccionario no sean nulos
            if (_mainWindowVM != null && _mainWindowVM.TerminosPorBBDD != null)
            {
                //Nos creamos la sublista a rellenar con los términos encontrados
                ObservableCollection<Termino> subLista = new ObservableCollection<Termino>();
                //Si el buscador no esta vaciío
                if (buscadorTextBox.Text != "")
                {
                    //Recogemos la longitud del texto introducido
                    int longitud = buscadorTextBox.Text.Length;
                    //Recorremos todos los términos de la lista
                    foreach (Termino termino in _mainWindowVM.TerminosPorBBDDAux)
                    {
                        string nombreTermino = "";
                        foreach (Ficha ficha in _mainWindowVM.GetFichasPorTermino(termino.IdTermino))
                        {
                            //Si el ID coincide y además el idioma coincide, asignamos el nombre
                            if (ficha.IdTermino == termino.IdTermino)
                                //Properties.Settings.Default.Idioma es una propiedad de la aplicación
                                //Para asignar un Identificador de idioma para poner nombre a los términos
                                //según el idioma seleccionado por el usuario
                                if (ficha.IdIdioma == Properties.Settings.Default.Idioma)
                                {
                                    nombreTermino = ficha.Nombre;
                                    //Comparamos ese nombre y si coincide los añadimos a la lista
                                    if (buscadorTextBox.Text.CompareTo(nombreTermino.Substring(0, longitud)) == 0)
                                        subLista.Add(termino);
                                }
                        }
                    }
                    //Asignamos la lista a nuestra ObservableCollection en el DataContext
                    _mainWindowVM.TerminosPorBBDD = subLista;
                }
                else
                {
                    //De lo contrario, tenemos una lista auxiliar para volver a rellenar
                    //todos los datos anteriores sin que se pierdan por el camino
                    _mainWindowVM.TerminosPorBBDD = _mainWindowVM.TerminosPorBBDDAux;
                }
            }
        }
        private void CommandBinding_Executed_AddTerm(object sender, ExecutedRoutedEventArgs e)
        {
            _mainWindowVM.AñadirTermino();
            Actualizar();
        }
        private void CommandBinding_CanExecute_AddTerm(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_mainWindowVM != null && _mainWindowVM.BBDD != null) e.CanExecute = true;
            else e.CanExecute = false;
        }
        private void CommandBinding_Executed_DeleteTerm(object sender, ExecutedRoutedEventArgs e)
        {
            _mainWindowVM.EliminarTermino();
            Actualizar();
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
                _mainWindowVM.EditarTermino();
                Actualizar();
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
            fichaWindow.Imagen = _mainWindowVM.TerminoSeleccionado.Imagen;
            foreach (Idioma idioma in _mainWindowVM.Idiomas)
                if (idioma.IdIdioma == _mainWindowVM.FichaSeleccionada.IdIdioma) fichaWindow.Idioma = idioma;

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
                _mainWindowVM.TerminoSeleccionado.Imagen = fichaWindow.Imagen;
                _mainWindowVM.EditarFicha();
                _mainWindowVM.EditarTermino();
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
                Diccionario bd = new Diccionario();
                bd.Nombre = nuevaBBDD.NombreBBDD;
                _mainWindowVM.AñadirBBDD(bd);
                DiccionarioSingleton.GetInstance()._diccionario = bd;
                Actualizar();
            }
        }
        private void CommandBinding_Executed_LoadDataBase(object sender, ExecutedRoutedEventArgs e)
        {
            CargarDiccionario cargarDiccionario = new CargarDiccionario();
            cargarDiccionario.Owner = this;
            cargarDiccionario.Diccionarios = _mainWindowVM.BBDDS;

            if (cargarDiccionario.ShowDialog() == true)
            {
                DiccionarioSingleton.GetInstance()._diccionario = cargarDiccionario.BBDD;
                Actualizar();
            }
        }
        private void CommandBinding_Executed_DeleteDataBase(object sender, ExecutedRoutedEventArgs e)
        {
            BorrarDiccionario borrarDiccionario = new BorrarDiccionario();
            borrarDiccionario.Owner = this;
            borrarDiccionario.Diccionarios = _mainWindowVM.BBDDS;

            if (borrarDiccionario.ShowDialog() == true)
            {
                _mainWindowVM.EliminarDiccionarios(borrarDiccionario.DiccionariosBorrados);
                //Actualizar();
            }
        }
        private void CommandBinding_Executed_Exit(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        private void CommandBinding_Executed_Help(object sender, ExecutedRoutedEventArgs e)
        {
            Help.ShowHelp(null, @"C:\Program Files (x86)\Terminously\TerminouslyInstaller\manual.chm");
        }
        private void Actualizar()
        {
            _mainWindowVM = new MainWindowVM();
            DataContext = _mainWindowVM;
        }
        private void datosTerminosListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
            fichaWindow.Imagen = _mainWindowVM.TerminoSeleccionado.Imagen;
            foreach (Idioma idioma in _mainWindowVM.Idiomas)
                if (idioma.IdIdioma == _mainWindowVM.FichaSeleccionada.IdIdioma) fichaWindow.Idioma = idioma;

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
                _mainWindowVM.TerminoSeleccionado.Imagen = fichaWindow.Imagen;
                _mainWindowVM.EditarFicha();
                _mainWindowVM.EditarTermino();
            }
        }
        private void IdiomaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IdiomaComboBox.SelectedItem != null)
            {
                Properties.Settings.Default.Idioma = (IdiomaComboBox.SelectedItem as Idioma).IdIdioma;
                Actualizar();
            }
        }
    }
}
