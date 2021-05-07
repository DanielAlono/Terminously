using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    public class Idioma : INotifyPropertyChanged
    {
        public string IdIdioma { get; set; }
        public string Nombre { get; set; }
        public byte[] Imagen { get; set; }
        public Idioma() { }
        public Idioma(string idIdioma, string nombre, byte[] imagen)
        {
            IdIdioma = idIdioma;
            Nombre = nombre;
            Imagen = imagen;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
