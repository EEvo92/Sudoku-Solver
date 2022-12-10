
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
            var linq = from item in this.casillas where item.fila == rownumber select item;


            foreach (Casilla cas in linq)
            {
                if (cas.Numero != 0)
                {
                    foreach (Casilla cas2 in linq)
                    {
                        if (cas2.Numero == 0)
                        {
                            casillas[(cas2.fila - 1) * 9 + (cas2.columna - 1)].Posibles.Remove(cas.Numero);
                        }
                    }
                }
            }
        }       
        public void SolveSuperCell(int supercellnumber)
        {
            var linq = from item in this.casillas where item.supercelda == supercellnumber select item;

            foreach (Casilla cas in linq)
            {
                if (cas.Numero != 0)
                {
                    foreach (Casilla cas2 in linq)
                    {
                        if (cas2.Numero == 0)
                        {
                            casillas[(cas2.fila - 1) * 9 + (cas2.columna - 1)].Posibles.Remove(cas.Numero);
                        }
                    }
                }
            }


        }
        public void SolveCol(int colnumber)
        {
            var linq = from item in this.casillas where item.columna == colnumber select item;

            foreach (Casilla cas in linq)
            {
                if (cas.Numero != 0)
                {
                    foreach (Casilla cas2 in linq)
                    {
                        if (cas2.Numero == 0)
                        {
                            casillas[(cas2.fila - 1) * 9 + (cas2.columna - 1)].Posibles.Remove(cas.Numero);
                        }
                    }
                }
            }
        }

        public void CheckIfCasSolved(Casilla cas)
        {
            if (cas.Posibles.Count == 1)
            {
                cas.Numero = cas.Posibles.ElementAt(1);
                solucionado = true;
            }
        }
    }
}
