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
        public int IdDiccionario { get; set; }
        public string Imagen { get; set; }
        public Termino()
        {
        }
        [JsonConstructor]
        public Termino(int idTermino, int idBBDD, string imagen)
        {
            IdTermino = idTermino;
            IdDiccionario = idBBDD;
            Imagen = imagen;
        }
        [JsonConstructor]
        public Termino(Termino termino)
        {
            IdTermino = termino.IdTermino;
            IdDiccionario = termino.IdDiccionario;
            Imagen = termino.Imagen;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
