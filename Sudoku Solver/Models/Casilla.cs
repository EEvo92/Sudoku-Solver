using System.Collections.Generic;

namespace Sudoku_Solver.Models
{
    public class Casilla
    {
        public int fila;

        public int columna;

        public int supercelda;
        public int Numero { get; set; }
        
        public List<int> Posibles { get; set; }

        public Casilla(int num, int fil, int col, int sup)
        {
            Numero = num;
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
            this.Numero = cas.Numero;           
            this.Posibles = cas.Posibles;
        }
    }
}
