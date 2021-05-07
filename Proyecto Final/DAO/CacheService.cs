using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    class CacheService
    {
        public ObservableCollection<Termino> Terminos { get; set; }
        public ObservableCollection<Ficha> Fichas { get; set; }

        public CacheService()
        {
            Terminos = new ObservableCollection<Termino>();
            Fichas = new ObservableCollection<Ficha>();
            InsertarDatos();
        }

        public ObservableCollection<Idioma> MisIdiomas()
        {
            Idioma español = new Idioma("ES", "Español", Properties.Resources.es);
            Idioma arabe = new Idioma("AR", "Árabe", Properties.Resources.ar);
            Idioma chino = new Idioma("CN", "Chino", Properties.Resources.cn);
            Idioma aleman = new Idioma("DE", "Alemán", Properties.Resources.de);
            Idioma ingles = new Idioma("EN", "Inglés", Properties.Resources.en);
            Idioma frances = new Idioma("FR", "Francés", Properties.Resources.fr);
            Idioma italiano = new Idioma("IT", "Italiano", Properties.Resources.it);
            Idioma japones = new Idioma("JP", "Japonés", Properties.Resources.jp);
            Idioma portugues = new Idioma("PT", "Portugués", Properties.Resources.pt);
            Idioma ruso = new Idioma("RU", "Ruso", Properties.Resources.ru);

            return new ObservableCollection<Idioma>()
            { español,arabe,chino,aleman,ingles,frances,italiano,japones,portugues,ruso };
        }
        public void AddTermino()
        {
            Termino termino = new Termino();
            termino.IdTermino = Terminos.Count() + 1;
            Terminos.Add(termino);
        }
        public void EdidTermino(Termino termino)
        {
            foreach (Termino term in Terminos)
            {
                if (term.IdTermino == termino.IdTermino)
                {
                    term.Imagen = termino.Imagen;
                    term.Fichas = termino.Fichas;
                }
            }
        }
        public void DeleteTermino(Termino termino)
        {
            foreach(Ficha f in Fichas)
            {
                if(termino.IdTermino == f.IdFicha)
                {
                    Fichas.Remove(f);
                }
            }
            Terminos.Remove(termino);
        }
        public void AddFicha(Ficha ficha)
        {
            Fichas.Add(ficha);
            AddFichaEnTermino(ficha);
        }
        public void EditFicha(Ficha ficha)
        {
            foreach (Ficha f in Fichas)
            {
                if(f.IdFicha == ficha.IdFicha)
                {
                    f.Nombre = ficha.Nombre;
                    f.CategoriaGramatical = ficha.CategoriaGramatical;
                    f.Definicion = ficha.Definicion;
                    f.FuenteDefinicion = ficha.FuenteDefinicion;
                    f.Registro = ficha.Registro;
                    f.Comentario = ficha.Comentario;
                    f.Idioma = ficha.Idioma;
                }
            }
        }
        public void DeleteFicha (Ficha ficha)
        {
            Fichas.Remove(ficha);
        }
        public void InsertarDatos()
        {
            Ficha ficha1 = new Ficha();
            ficha1.IdFicha = 1;
            ficha1.IdTermino = 1;
            ficha1.Nombre = "Disco duro";
            ficha1.CategoriaGramatical = CategoriaGramatical.Sustantivo;
            ficha1.Definicion = "Disco con una gran capacidad de almacenamiento de datos informáticos que se encuentra insertado permanentemente" +
                " en la unidad central de procesamiento de la computadora.";
            ficha1.FuenteDefinicion = "Wikipedia";
            ficha1.Registro = Registro.Tecnicismo;
            ficha1.Idioma = new Idioma("ES", "Español", Properties.Resources.es);

            Ficha ficha2 = new Ficha();
            ficha2.IdFicha = 2;
            ficha2.IdTermino = 1;
            ficha2.Nombre = "Hard Drive";
            ficha2.CategoriaGramatical = CategoriaGramatical.Sustantivo;
            ficha2.Definicion = "A hard disk drive (HDD), hard disk, hard drive, or fixed disk[b] is an electro-mechanical data storage device" +
                " that stores and retrieves digital data using magnetic storage and one or more rigid rapidly rotating platters coated with " +
                "magnetic material.";
            ficha2.FuenteDefinicion = "Wikipedia";
            ficha2.Registro = Registro.Tecnicismo;
            ficha2.Idioma = new Idioma("EN", "Inglés", Properties.Resources.en);

            Ficha ficha3 = new Ficha();
            ficha3.IdFicha = 3;
            ficha3.IdTermino = 2;
            ficha3.Nombre = "Inteligente";
            ficha3.CategoriaGramatical = CategoriaGramatical.Adjetivo;
            ficha3.Definicion = "Dotado de inteligencia";
            ficha3.FuenteDefinicion = "RAE";
            ficha3.Registro = Registro.Coloquial;
            ficha3.Idioma = new Idioma("ES", "Español", Properties.Resources.es);

            Ficha ficha4 = new Ficha();
            ficha4.IdFicha = 4;
            ficha4.IdTermino = 2;
            ficha4.Nombre = "Smart";
            ficha4.CategoriaGramatical = CategoriaGramatical.Adjetivo;
            ficha4.Definicion = "Having or showing a quick-witted intelligence.";
            ficha4.FuenteDefinicion = "Oxford";
            ficha4.Registro = Registro.Coloquial;
            ficha4.Idioma = new Idioma("ES", "Inglés", Properties.Resources.en);

            Termino termino1 = new Termino();
            termino1.IdTermino = 1;
            termino1.Fichas.Add(ficha1);
            termino1.Fichas.Add(ficha2);

            Termino termino2 = new Termino();
            termino2.IdTermino = 2;
            termino2.Fichas.Add(ficha3);
            termino2.Fichas.Add(ficha4);

            Terminos.Add(termino1);
            Terminos.Add(termino2);
        }
        public ObservableCollection<Ficha> ObtenerFichasPorTermino(Termino termino)
        {
            ObservableCollection<Ficha> fichasPorTermino = new ObservableCollection<Ficha>();
            foreach (Ficha ficha in Fichas)
                if (ficha.IdTermino == termino.IdTermino)
                    fichasPorTermino.Add(ficha);

            return fichasPorTermino;
        }
        public ObservableCollection<Ficha> ObtenerFichasPorIdTermino(int idTermino)
        {
            ObservableCollection<Ficha> fichasPorTermino = new ObservableCollection<Ficha>();
            foreach (Ficha ficha in Fichas)
                if (ficha.IdTermino == idTermino)
                    fichasPorTermino.Add(ficha);

            return fichasPorTermino;
        }
        public void AddFichaEnTermino(Ficha ficha)
        {
            foreach(Termino termino in Terminos)
            {
                if (termino.IdTermino == ficha.IdTermino)
                    termino.Fichas.Add(ficha);
            }
        }
        public void DeleteFichaEnTermino(Ficha ficha)
        {
            foreach(Termino termino in Terminos)
            {
                if (termino.IdTermino == ficha.IdTermino)
                    termino.Fichas.Remove(ficha);
            }
        }
    }
}
