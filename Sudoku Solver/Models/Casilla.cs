using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku_Solver.Models
{
    class Casilla
    {
        public bool solucionado = false;
        public int Numero { get; set; }
        private int[] Posibles { get; set; }

        public Casilla()
        {
            Numero = 0;
            Posibles = new int[9];
        }
    }
}
