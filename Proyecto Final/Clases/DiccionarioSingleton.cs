using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    class DiccionarioSingleton
    {
        public Diccionario _diccionario { get; set; }
        private DiccionarioSingleton() { }
        private static DiccionarioSingleton _instance;
        public static DiccionarioSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DiccionarioSingleton();
            }
            return _instance;
        }
    }
}
