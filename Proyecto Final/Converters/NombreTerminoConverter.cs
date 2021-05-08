using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Proyecto_Final
{
    class NombreTerminoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ApiRestService _servicio;
            if (value != null && MainWindowVM.TerminosPorBBDD != null)
            {
                _servicio = new ApiRestService();
                ObservableCollection<Termino> terminos = _servicio.GetTerminos();
                for (int i = 0; i < terminos.Count; i++)
                    foreach (Ficha ficha in _servicio.GetFichas())
                        if(terminos[i].IdTermino == ficha.IdTermino && ficha.IdIdioma == ((Idioma)value).IdIdioma)
                            return ficha.Nombre;
            }

            return "Idioma no asignado";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
