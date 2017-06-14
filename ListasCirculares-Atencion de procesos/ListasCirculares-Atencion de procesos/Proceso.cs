using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasCirculares_Atencion_de_procesos
{
    class Proceso
    {
        public Proceso siguente { get; set; }
        public int _ciclosProceso { get; private set; }
        static Random random = new Random();

        public Proceso()
        {
            _ciclosProceso = random.Next(4, 13);
            siguente = null;
        }

        public int ciclosRestantes()
        {
            _ciclosProceso--;
            return _ciclosProceso;
        }

        public override string ToString()
        {
            return "Ciclos necesarios: " + _ciclosProceso + Environment.NewLine;
        }
    }
}
