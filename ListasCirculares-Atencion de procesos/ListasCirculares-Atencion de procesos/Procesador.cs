using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasCirculares_Atencion_de_procesos
{
    class Procesador
    {
        public Proceso inicio { get; private set; }
        public Proceso fin { get; private set; }
        public int _totalProcesos { get; private set; }
        public int _ciclosNecesarios { get; private set; }
        public int _atendidos { get; private set; }
        public int _atencion { get; private set; }

        public Procesador()
        {
            this._atendidos = 0;
            this._ciclosNecesarios = 0;
            this._totalProcesos = 0;
            this._atencion = 0;
            this.inicio = null;
            this.fin = null;
        }

        public void push(Proceso p)
        {
            if (inicio != null) {
                fin.siguente = p;
                p.siguente = inicio;
                fin = p;
            }
            else {
                inicio = p;
                p.siguente = inicio;
                fin = p;
            }
            _totalProcesos++;
            _ciclosNecesarios += p._ciclosProceso;
        }

        public void pop(int ciclosRestantes)
        {
            bool val = false;
            if (ciclosRestantes == 0) {
                if (inicio == null)
                    val = true;
                else if (inicio.siguente == inicio) {
                    inicio = null;
                    _totalProcesos--;
                    _atendidos++;
                }
                else {
                    inicio = inicio.siguente;
                    fin.siguente = inicio;
                    _totalProcesos--;
                    _atendidos++;
                    inicio = inicio.siguente;
                    val = true;
                }

            }
            if (val == false)
                inicio = inicio.siguente;
        }

        public int procesar()
        {
            int restantes;
            restantes = inicio.ciclosRestantes();
            _atencion++;
            _ciclosNecesarios--;
            return restantes;
        }
    }
}
