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
            if (value != null)
            {
                foreach (Ficha ficha in ((ObservableCollection<Ficha>)value))
                    if (MainWindowVM.IdiomaSeleccionado != null && ficha.Idioma.IdIdioma == MainWindowVM.IdiomaSeleccionado.IdIdioma)
                        return ficha.Nombre;
            }
            return "Falta ficha en ese idioma";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
