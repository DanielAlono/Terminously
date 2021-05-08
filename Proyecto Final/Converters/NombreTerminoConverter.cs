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
            ApiRestService _servicio = new ApiRestService();
            if (value != null)
            {
                foreach (Ficha ficha in _servicio.GetFichas())
                    if (ficha.IdTermino == ((int)value) /*&& ficha.IdIdioma == Properties.Settings.Default.Idioma*/)
                        return ficha.Nombre;
            }

            return "Asignar fichas";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
