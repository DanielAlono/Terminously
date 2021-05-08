using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    class MainWindowVM : INotifyPropertyChanged
    {
        public Diccionario BBDD { get; set; }
        public Termino TerminoSeleccionado { get; set; }
        public Ficha NuevaFicha { get; set; }
        public Ficha FichaSeleccionada { get; set; }
        public static Idioma IdiomaSeleccionado { get; set; }
        public ObservableCollection<Diccionario> BBDDS { get; set; }
        public ObservableCollection<Termino> Terminos { get; set; }
        public ObservableCollection<Termino> TerminosPorBBDD { get; set; }
        public ObservableCollection<Ficha> Fichas { get; set; }
        public ObservableCollection<Ficha> FichasPorTermino { get; set; }
        public ObservableCollection<Idioma> Idiomas { get; set; }
        private ApiRestService _servicio;
        public MainWindowVM()
        {
            _servicio = new ApiRestService();
            BBDD = DiccionarioSingleton.GetInstance()._diccionario;
            BBDDS = _servicio.GetBBDDS();
            Idiomas = _servicio.GetIdiomas();
            Fichas = _servicio.GetFichas();
            Terminos = _servicio.GetTerminos();
            if(BBDD != null)
                TerminosPorBBDD = GetTerminosPorBBDD(BBDD.IdDiccionario);
        }
        public void AñadirBBDD(Diccionario bbdd)
        {
            _servicio.PostBBDD(bbdd);
            BBDDS = _servicio.GetBBDDS();
        }
        public void AñadirTermino()
        {
            Termino termino = new Termino(Terminos.Count + 1, BBDD.IdDiccionario, "");
            _servicio.PostTermino(termino);
            Terminos.Add(termino);
            TerminosPorBBDD.Add(termino);
        }
        public void EditarTermino()
        {
            _servicio.PutTermino(TerminoSeleccionado);
            TerminosPorBBDD = GetTerminosPorBBDD(BBDD.IdDiccionario);
            FichasPorTermino = GetFichasPorTermino(TerminoSeleccionado.IdTermino);
        }
        public void EliminarTermino()
        {
            _servicio.DeleteTermino(TerminoSeleccionado);
            TerminosPorBBDD = GetTerminosPorBBDD(BBDD.IdDiccionario);
        }
        public void AñadirFicha()
        {
            _servicio.PostFicha(NuevaFicha);
            FichasPorTermino = GetFichasPorTermino(TerminoSeleccionado.IdTermino);
        }
        public void EliminarFicha()
        {
            _servicio.DeleteFicha(FichaSeleccionada);
            FichasPorTermino = GetFichasPorTermino(TerminoSeleccionado.IdTermino);
        }
        public void EditarFicha()
        {
            _servicio.PutFicha(FichaSeleccionada);
            FichasPorTermino = GetFichasPorTermino(TerminoSeleccionado.IdTermino);
        }
        public ObservableCollection<Termino> GetTerminosPorBBDD(int idBBDD)
        {
            Terminos = _servicio.GetTerminos();
            ObservableCollection<Termino> terminos = new ObservableCollection<Termino>();
            foreach (Termino termino in Terminos)
                if (termino.IdDiccionario == idBBDD)
                    terminos.Add(termino);

            return terminos;
        }
        public ObservableCollection<Ficha> GetFichasPorTermino(int idTermino)
        {
            ObservableCollection<Ficha> fichas = new ObservableCollection<Ficha>();
            foreach (Ficha ficha in Fichas)
                if (ficha.IdTermino == idTermino)
                    fichas.Add(ficha);

            return fichas;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
