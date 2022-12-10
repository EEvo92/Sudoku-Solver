using Sudoku_Solver.Models;

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
            for (int j = 1; j < 10; j++)
            { 
                for (int i = 1; i < 10; i++)
                {
                    sudo.SolveCol(i);
                    sudo.SolveRow(i);
                    sudo.SolveSuperCell(i);                    
                }
            }
        }

        public void SolveRows()
        {
            for (int i = 1; i < 10; i++)
            {
                sudo.SolveRow(i);
            }
        }
    }
}
