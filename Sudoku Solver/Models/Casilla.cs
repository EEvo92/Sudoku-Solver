using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sudoku_Solver.Models
{
    class Casilla
    {
        public bool solucionado;

        public int fila;

        public int columna;

        public int supercelda;
        public int Numero { get; set; }
        public int[] Posibles { get; set; }

        public int NumPosibles { get; set; }

        public Casilla(int num, int fil, int col, int sup)
        {
            if (num != 0)
            {
                NumPosibles = 0;
                solucionado = true;
            }
            else
            {
                NumPosibles = 9;
                solucionado = false;
            }

            Numero = num;
            Posibles = new int []{ 1, 2, 3, 4, 5, 6, 7, 8, 9};
            
            fila = fil;
            columna = col;
            supercelda = sup;
        }

        public void CheckPosiblesCasilla()
        {
            foreach (int i in Posibles)
            {
                if ((i == 0) && (NumPosibles > 0))
                {
                    NumPosibles--;
                }
            }
            if (NumPosibles == 1)
            {
                var linq = from item in this.Posibles where item != 0 select item;
                this.Numero = linq.ElementAt(0);
                this.solucionado = true;

            }
        }
    }
}
