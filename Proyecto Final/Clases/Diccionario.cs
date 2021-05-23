using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    public class Diccionario : INotifyPropertyChanged
    {
        public int IdDiccionario { get; set; }
        public string Nombre { get; set; }
        [JsonConstructor]
        public Diccionario(int idDiccionario, string nombre)
        {
            IdDiccionario = idDiccionario;
            Nombre = nombre;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
