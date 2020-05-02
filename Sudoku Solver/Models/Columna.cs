using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku_Solver.Models
{
    class Columna
    {
        public bool solucionado = false;
        public int Numero { get; set; }
        public Casilla[] casillas { get; set; }
        public Columna()
        {
            casillas = new Casilla[9];
        }
    }
}
