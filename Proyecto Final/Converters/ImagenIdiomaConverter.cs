using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Proyecto_Final
{
    class ImagenIdiomaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch (value)
                {
                    case "AR":
                        return "Resources/ar.png";
                    case "ARG":
                        return "Resources/arg.png";
                    case "CN":
                        return "Resources/cn.png";
                    case "DE":
                        return "Resources/de.png";
                    case "EN":
                        return "Resources/en.png";
                    case "ES":
                        return "Resources/es.png";
                    case "FR":
                        return "Resources/fr.png";
                    case "IT":
                        return "Resources/it.png";
                    case "JP":
                        return "Resources/jp.png";
                    case "PT":
                        return "Resources/pt.png";
                    case "RU":
                        return "Resources/ru.png";
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
