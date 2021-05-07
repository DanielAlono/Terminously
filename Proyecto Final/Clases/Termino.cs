using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    public class Termino : INotifyPropertyChanged
    {
        public int IdTermino { get; set; }
        public int IdBBDD { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public ObservableCollection<Ficha> Fichas { get; set; }
        public Termino() {
            Fichas = new ObservableCollection<Ficha>();
        }
        [JsonConstructor]
        public Termino(int idTermino, int idBBDD, string imagen)
        {
            IdTermino = idTermino;
            IdBBDD = idBBDD;
            Imagen = imagen;
            Fichas = new ObservableCollection<Ficha>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
