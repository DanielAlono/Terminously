using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    public class BBDD : INotifyPropertyChanged
    {
        public int IdBBDD { get; set; }
        public string Nombre { get; set; }
        [JsonConstructor]
        public BBDD (int idBBDD, string nombre)
        {
            IdBBDD = idBBDD;
            Nombre = nombre;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
