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
        public Idioma IdiomaSeleccionado { get; set; }
        public ObservableCollection<Diccionario> BBDDS { get; set; }
        public ObservableCollection<Termino> Terminos { get; set; }
        public static ObservableCollection<Termino> TerminosPorBBDD { get; set; }
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
            AsignarImagenIdiomas(Idiomas);
            Fichas = _servicio.GetFichas();
            Terminos = _servicio.GetTerminos();
            if (BBDD != null)
                TerminosPorBBDD = GetTerminosPorBBDD(BBDD.IdDiccionario);
        }
        public void AñadirBBDD(Diccionario bbdd)
        {
            _servicio.PostBBDD(bbdd);
            BBDDS.Add(bbdd);
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
        }
        public void EliminarTermino()
        {
            _servicio.DeleteTermino(TerminoSeleccionado);
            TerminosPorBBDD.Remove(TerminoSeleccionado);
            Terminos.Remove(TerminoSeleccionado);
        }
        public void AñadirFicha()
        {
            _servicio.PostFicha(NuevaFicha);
            Fichas.Add(NuevaFicha);
        }
        public void EliminarFicha()
        {
            _servicio.DeleteFicha(FichaSeleccionada);
            Fichas.Remove(FichaSeleccionada);
        }
        public void EditarFicha()
        {
            _servicio.PutFicha(FichaSeleccionada);
            Fichas = _servicio.GetFichas();
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
        public void AsignarImagenIdiomas(ObservableCollection<Idioma> idiomas)
        {
            foreach (Idioma idioma in idiomas)
            {
                switch (idioma.IdIdioma)
                {
                    case "AR":
                        idioma.Imagen = Properties.Resources.ar;
                        break;
                    case "CN":
                        idioma.Imagen = Properties.Resources.cn;
                        break;
                    case "DE":
                        idioma.Imagen = Properties.Resources.de;
                        break;
                    case "EN":
                        idioma.Imagen = Properties.Resources.en;
                        break;
                    case "ES":
                        idioma.Imagen = Properties.Resources.es;
                        break;
                    case "FR":
                        idioma.Imagen = Properties.Resources.fr;
                        break;
                    case "IT":
                        idioma.Imagen = Properties.Resources.it;
                        break;
                    case "JP":
                        idioma.Imagen = Properties.Resources.jp;
                        break;
                    case "PT":
                        idioma.Imagen = Properties.Resources.pt;
                        break;
                    case "RU":
                        idioma.Imagen = Properties.Resources.ru;
                        break;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
