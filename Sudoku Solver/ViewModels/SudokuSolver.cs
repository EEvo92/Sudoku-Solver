using Sudoku_Solver.Models;
using System.Linq;

namespace Sudoku_Solver.ViewModels
{
    public class SudokuSolver
    {
        public Sudoku sudo;
        public SudokuSolver()
        {
            sudo = new Sudoku();
        }

        public void Solve()
        {
            for (int j = 1; j < 10; j++)
            { 
                for (int i = 1; i < 10; i++)
                {
                    SolveCol(i);
                    SolveRow(i);
                    SolveSuperCell(i);
                    
                }
            }
        }

        public void SolveRows()
        {
            for (int i = 1; i < 10; i++)
            {
                DeleteIndividualCandidates();
            }
        }

        public void SolveRow(int rownumber)
        {
            var linq = from item in sudo.Casillas where item.fila == rownumber select item;


            foreach (Casilla cas in linq)
            {
                if (cas.Numero != 0)
                {
                    foreach (Casilla cas2 in linq)
                    {
                        if (cas2.Numero == 0)
                        {
                            sudo.Casillas[(cas2.fila - 1) * 9 + (cas2.columna - 1)].Posibles.Remove(cas.Numero);
                        }
                    }
                }
            }
        }
        public void SolveSuperCell(int supercellnumber)
        {
            var linq = from item in sudo.Casillas where item.supercelda == supercellnumber select item;

            foreach (Casilla cas in linq)
            {
                if (cas.Numero != 0)
                {
                    foreach (Casilla cas2 in linq)
                    {
                        if (cas2.Numero == 0)
                        {
                            sudo.Casillas[(cas2.fila - 1) * 9 + (cas2.columna - 1)].Posibles.Remove(cas.Numero);
                        }
                    }
                }
            }


        }
        public void SolveCol(int colnumber)
        {
            var linq = from item in sudo.Casillas where item.columna == colnumber select item;

            foreach (Casilla cas in linq)
            {
                if (cas.Numero != 0)
                {
                    foreach (Casilla cas2 in linq)
                    {
                        if (cas2.Numero == 0)
                        {
                            sudo.Casillas[(cas2.fila - 1) * 9 + (cas2.columna - 1)].Posibles.Remove(cas.Numero);
                        }
                    }
                }
            }
        }

        public void CheckIfCasSolved(Casilla cas)
        {
            if (cas.Numero == 0)
            {
                if (cas.Posibles.Count == 1)
                {
                    cas.Numero = cas.Posibles.ElementAt(1);
                }
            }
        }

        public void DeleteIndividualCandidates()
        {
            for (int i = 1; i < 10; i++)
            {
                var linq = from item in sudo.Casillas where item.fila == i select item;
                for (int j = 1; j < 10; j++)
                {
                    var linq2 = from item in linq.ToList() where (item.Posibles.Contains(j) & item.Numero == 0) select item;
                    if (linq2.Count() == 1)
                    {
                        sudo.Casillas[(linq2.First().fila - 1) * 9 + (linq2.First().columna - 1)].Numero = j;
                    }
                }
            }
            for (int i = 1; i < 10; i++)
            {
                var linq = from item in sudo.Casillas where item.columna == i select item;
                for (int j = 1; j < 10; j++)
                {
                    var linq2 = from item in linq.ToList() where (item.Posibles.Contains(j) & item.Numero == 0) select item;
                    if (linq2.Count() == 1)
                    {
                        sudo.Casillas[(linq2.First().fila - 1) * 9 + (linq2.First().columna - 1)].Numero = j;
                    }
                }

            }
            for (int i = 1; i < 10; i++)
            {
                var linq = from item in sudo.Casillas where item.supercelda == i select item;
                for (int j = 1; j < 10; j++)
                {
                    var linq2 = from item in linq.ToList() where (item.Posibles.Contains(j) & item.Numero == 0) select item;
                    if (linq2.Count() == 1)
                    {
                        sudo.Casillas[(linq2.First().fila - 1) * 9 + (linq2.First().columna - 1)].Numero = j;
                    }
                }

            }
        }
    }
}
