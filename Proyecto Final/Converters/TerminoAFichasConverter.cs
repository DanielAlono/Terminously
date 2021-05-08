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
    class TerminoAFichasConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ApiRestService _sercicio;
            ObservableCollection<Ficha> fichas;
            ObservableCollection<Ficha> fichasPorTermino = new ObservableCollection<Ficha>();
            if (value != null)
            {
                _sercicio = new ApiRestService();
                fichas = _sercicio.GetFichas();

                foreach(Ficha ficha in fichas)
                {
                    if (((Termino)value).IdTermino == ficha.IdTermino)
                        fichasPorTermino.Add(ficha);
                }
            }
            return fichasPorTermino;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
