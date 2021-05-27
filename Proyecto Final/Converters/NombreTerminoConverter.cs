using System;
using System.Globalization;
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
                    if (ficha.IdTermino == ((int)value))
                        if (ficha.IdIdioma == Properties.Settings.Default.Idioma)
                            return ficha.Nombre;
            }

            return "Asignar ficha en " + Properties.Settings.Default.Idioma;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
