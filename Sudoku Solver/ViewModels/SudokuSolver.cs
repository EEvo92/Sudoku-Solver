using Sudoku_Solver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku_Solver.ViewModels
{
    class SudokuSolver
    {
        public Sudoku sudo;

        public SudokuSolver()
        {
            sudo = new Sudoku();
        }

        public void Solve()
        {
            for (int i = 1; i < 10; i++)
            {
                sudo.SolveRow(i);
            }
        }
    }
}
