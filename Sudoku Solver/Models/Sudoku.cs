
using System.Linq;

namespace Sudoku_Solver.Models
{
    class Sudoku
    {
        public bool solucionado = false;
        public Casilla[] casillas { get; set; }
        public Fila[] filas { get; set; }
        
        public Sudoku()
        {
            casillas = new Casilla[81];
            filas = new Fila[9];
        }
        public void SolveRow(int rownumber)
        {
            Fila row = filas[rownumber-1];

            foreach (Casilla cas in row.casillas)
            {
                if (!cas.solucionado)
                {
                    Casilla casaux;                   

                    for (int i = 0; i < 9; i++)
                    {
                        casaux = filas[i].casillas[cas.columna -1];
                        if (casaux.Numero != 0)
                        {
                            cas.Posibles[casaux.Numero - 1] = 0;
                        }
                    }
                    cas.ChecIfSolved();
                }                
            }
        }        
        public void SolveSuperCell(int supercellnumber)
        {
            Supercelda supercell = new Supercelda();
            int i = 0;
            foreach (Fila row in filas)
            {
                foreach (Casilla cas in row.casillas)
                {
                    if (cas.supercelda == supercellnumber)
                    {
                        supercell.casillas[i] = cas;
                        i++;
                    }
                }
            }

            foreach (Casilla cas in supercell.casillas)
            {
                if (!cas.solucionado)
                {
                    foreach (Casilla casaux in supercell.casillas)
                    {
                        if (casaux.Numero != 0)
                        {
                            cas.Posibles[casaux.Numero - 1] = 0;
                        }
                    }
                    cas.ChecIfSolved();
                }
                
            }

        }
        public void CheckInsideCol(int rownumber)
        {
            Fila row = filas[rownumber - 1];
            foreach (Casilla cas in row.casillas)
            {
                if (!cas.solucionado)
                {
                    foreach (Casilla casaux in row.casillas)
                    {              
                        if (casaux.Numero != 0)
                        {
                            cas.Posibles[casaux.Numero - 1] = 0;
                        }
                    }
                    cas.ChecIfSolved();
                }
            }
        }
        public void AddRow(Fila fila, int rownumber)
        {
            filas[rownumber] = fila;
        }
        public void HiddenCandidatesRow(int rownumber)
        {
            int[] apariciones = {0, 0, 0, 0, 0, 0, 0, 0, 0};
            foreach (Casilla cas in filas[rownumber-1].casillas)
            {
                Casilla casaux = new Casilla(cas);
                if (!casaux.solucionado)
                {
                    foreach (int posibleaux in casaux.Posibles)
                    {
                        if (posibleaux != 0)
                        {
                            apariciones[posibleaux - 1]++;
                        }                       
                    }
                }
            }

            int pos = 0;
            foreach(int apar in apariciones)
            {
                if (apar == 1)
                {
                   foreach(Casilla cas in filas[rownumber - 1].casillas)
                   {
                        if ((!cas.solucionado) && (cas.Posibles[pos] == pos+1))
                        {
                            cas.Numero = pos + 1;
                            cas.ChecIfSolved();
                        }
                    }
                }
                pos++;
            }
        }

        public void HiddenCandidatesCol(int colnumber)
        {
            int[] apariciones = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Casilla[] col = new Casilla[9];
            for (int i =0; i<9; i++)
            {
                col[i] = filas[i].casillas[colnumber-1];
            }

            foreach (Casilla cas in col)
            {
                Casilla casaux = new Casilla(cas);
                if (!casaux.solucionado)
                {
                    foreach (int posibleaux in casaux.Posibles)
                    {
                        if (posibleaux != 0)
                        {
                            apariciones[posibleaux - 1]++;
                        }
                    }
                }
            }

            int pos = 0;
            foreach (int apar in apariciones)
            {
                if (apar == 1)
                {
                    foreach (Casilla cas in col)
                    {
                        if ((!cas.solucionado) && (cas.Posibles[pos] == pos + 1))
                        {
                            filas[pos].casillas[colnumber-1].Numero =  pos +1;
                            filas[pos].casillas[colnumber-1].ChecIfSolved();
                        }
                    }
                }
                pos++;
            }
        }
    }
}
