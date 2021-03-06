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
        public ObservableCollection<Termino> TerminosPorBBDD { get; set; }
        public ObservableCollection<Termino> TerminosPorBBDDAux { get; set; }
        public ObservableCollection<Ficha> Fichas { get; set; }
        public ObservableCollection<Ficha> FichasPorBBDD { get; set; }
        public ObservableCollection<Idioma> Idiomas { get; set; }
        private ApiRestService _servicio;
        public MainWindowVM()
        {
            _servicio = new ApiRestService();
            BBDD = DiccionarioSingleton.GetInstance()._diccionario;
            BBDDS = _servicio.GetBBDDS();
            Terminos = _servicio.GetTerminos();
            Idiomas = _servicio.GetIdiomas();
            AsignarImagenIdiomas(Idiomas);
            Fichas = _servicio.GetFichas();
            
            if (BBDD != null)
            {
                TerminosPorBBDD = GetTerminosPorBBDD(BBDD.IdDiccionario);
                TerminosPorBBDDAux = GetTerminosPorBBDD(BBDD.IdDiccionario);
                FichasPorBBDD = GetFichasPorBBDD(BBDD.IdDiccionario);
            }
        }
        public void AñadirBBDD(Diccionario bbdd)
        {
            _servicio.PostBBDD(bbdd);
            BBDDS = _servicio.GetBBDDS();
        }
        public void EliminarDiccionarios(ObservableCollection<Diccionario> diccionarios)
        {
            foreach (Diccionario diccionario in diccionarios)
                _servicio.DeleteBBDD(diccionario);
            BBDDS = _servicio.GetBBDDS();
        }
        public void AñadirTermino()
        {
            Termino termino = new Termino();
            termino.IdDiccionario = BBDD.IdDiccionario;
            termino.Imagen = "";
            _servicio.PostTermino(termino);
            TerminosPorBBDD = GetTerminosPorBBDD(BBDD.IdDiccionario);
        }
        public void EditarTermino()
        {
            _servicio.PutTermino(TerminoSeleccionado);
            TerminosPorBBDD = GetTerminosPorBBDD(BBDD.IdDiccionario);
        }
        public void EliminarTermino()
        {
            _servicio.DeleteTermino(TerminoSeleccionado);
            TerminosPorBBDD = GetTerminosPorBBDD(BBDD.IdDiccionario);
        }
        public void AñadirFicha()
        {
            _servicio.PostFicha(NuevaFicha);
            Fichas = _servicio.GetFichas();
        }
        public void EliminarFicha()
        {
            _servicio.DeleteFicha(FichaSeleccionada);
            Fichas = _servicio.GetFichas();
        }
        public void EditarFicha()
        {
            _servicio.PutFicha(FichaSeleccionada);
            Fichas = _servicio.GetFichas();
        }
        public ObservableCollection<Termino> GetTerminosPorBBDD(int idBBDD)
        {
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
        public ObservableCollection<Ficha> GetFichasPorBBDD(int idBBDD)
        {
            ObservableCollection<Ficha> fichas = new ObservableCollection<Ficha>();
            foreach (Termino termino in TerminosPorBBDD)
                foreach (Ficha ficha in GetFichasPorTermino(termino.IdTermino))
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
                    case "ARG":
                        idioma.Imagen = Properties.Resources.arg;
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
