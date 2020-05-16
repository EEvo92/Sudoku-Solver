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
                    sudo.CheckInsideCol(i);
                    sudo.SolveRow(i);
                    sudo.SolveSuperCell(i);
                    
                }
            }
            for (int i = 1; i < 10; i++)
            {
                sudo.HiddenCandidatesRow(i);
               // sudo.HiddenCandidatesCol(i);
            }
        }
    }
}
