using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    public enum CategoriaGramatical
    {
        Adjetivo, Adverbio, Conjunción,
        Determinante, Interjección, Preposición,
        Pronombre, Sustantivo, Verbo
    }
    public enum Registro
    {
        Latinismo, Cultismo, Tecnicismo, Formal, Coloquial, Vulgar
    }
    public class Ficha : INotifyPropertyChanged
    {
        public int IdFicha { get; set; }
        public int IdTermino { get; set; }
        public string Nombre { get; set; }
        public CategoriaGramatical CategoriaGramatical { get; set; }
        public string Definicion { get; set; }
        public string FuenteDefinicion { get; set; }
        public Registro Registro { get; set; }
        public string Comentario { get; set; }
        public string IdIdioma { get; set; }

        public Ficha() { }
        [JsonConstructor]
        public Ficha(int idFicha, int idTermino, string nombre, CategoriaGramatical categoriaGramatical, string definicion, string fuenteDefinicion, Registro registro, string comentario, string idIdioma)
        {
            IdFicha = idFicha;
            IdTermino = idTermino;
            Nombre = nombre;
            CategoriaGramatical = categoriaGramatical;
            Definicion = definicion;
            FuenteDefinicion = fuenteDefinicion;
            Registro = registro;
            Comentario = comentario;
            IdIdioma = idIdioma;
        }
        public Ficha(Ficha ficha)
        {
            IdFicha = ficha.IdFicha;
            IdTermino = ficha.IdTermino;
            Nombre = ficha.Nombre;
            CategoriaGramatical = ficha.CategoriaGramatical;
            Definicion = ficha.Definicion;
            FuenteDefinicion = ficha.FuenteDefinicion;
            Registro = ficha.Registro;
            Comentario = ficha.Comentario;
            IdIdioma = ficha.IdIdioma;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
