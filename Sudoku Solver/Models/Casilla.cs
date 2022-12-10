using System.Linq;
using System.Collections.Generic;

namespace Sudoku_Solver.Models
{
    class Casilla
    {
        public bool solucionado;

        public int fila;

        public int columna;

        public int supercelda;
        public int Numero { get; set; }
        //public int[] Posibles { get; set; }

        public List<int> Posibles { get; set; }

        public Casilla(int num, int fil, int col, int sup)
        {
            if (num != 0) { solucionado = true;}
            else { solucionado = false; }

            Numero = num;
            //Posibles = new int []{ 1, 2, 3, 4, 5, 6, 7, 8, 9};
            Posibles = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            fila = fil;
            columna = col;
            supercelda = sup;
        }

        public Casilla( Casilla cas)
        {
            this.fila = cas.fila;
            this.columna = cas.columna;
            this.supercelda = cas.supercelda;
            this.solucionado = cas.solucionado;
            this.Numero = cas.Numero;           
            this.Posibles = cas.Posibles;
        }
    }
}
