using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sudoku_Solver.Models
{
    class Sudoku
    {
        public bool solucionado = false;
        public Casilla[] casillas { get; set; }
        
        public Sudoku()
        {
            casillas = new Casilla[81];
        }

        public void SolveRow(int rownumber)
        {
            Casilla[] row = casillas[(rownumber*9-9)..(rownumber*9)];

            foreach (Casilla cas in row)
            {
                if (cas.Numero == 0)
                {
                    Casilla casaux;
                    

                    for (int i = 0; i < 9; i++)
                    {
                        int numcasilla = (i) * 9 + (cas.columna - 1);
                        casaux = casillas[numcasilla];
                        if (casaux.Numero != 0)
                        {
                            cas.Posibles[casaux.Numero - 1] = 0;
                        }
                    }                    
                }

                cas.CheckPosiblesCasilla();
            }
        }
         

















    }
}
