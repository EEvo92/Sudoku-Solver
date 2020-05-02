using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku_Solver.Models
{
    class Sudoku
    {
        public bool solucionado = false;
        public Casilla[] casillas { get; set; }
        public Fila[] filas { get; set; }
        public Columna[] columnas { get; set; }
        public Supercelda[] superceldas { get; set; }

        public Sudoku()
        {
            casillas = new Casilla[81];
            filas = new Fila[9];
            columnas = new Columna[9];
            superceldas = new Supercelda[9];
        }


    }
}
