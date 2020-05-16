using Sudoku_Solver.Models;
using Sudoku_Solver.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Sudoku_Solver
{
    public partial class MainWindow : Window
    {
        private SudokuSolver sudoSolver = new SudokuSolver();
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            DataContext = sudoSolver;

        }
        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            AdquireData();
            sudoSolver.Solve();
            ShowData();
        }
        private void AdquireData()
        {
            int rownumber = 1;
            int colnumber = 1;
            int supercellnumber = 1;
            Fila row = new Fila();

            foreach (TextBox Celda in Sudoku.Children)
            {
                supercellnumber = DeterminateSupercell(rownumber, colnumber);
                int numero = 0;

                try
                {
                    numero = Int32.Parse(Celda.Text);
                    if (Celda.Text.Equals(""))
                    {
                        row.casillas[colnumber-1] = new Casilla(0, rownumber, colnumber, supercellnumber);
                    }
                    else
                    {
                        if (Celda.Text.Length == 1)
                        {
                            row.casillas[colnumber - 1] = new Casilla(numero, rownumber, colnumber, supercellnumber);
                        }
                        else
                        {
                            row.casillas[colnumber - 1] = new Casilla(0, rownumber, colnumber, supercellnumber);
                        }
                    }

                    if (colnumber == 9)
                    {
                        sudoSolver.sudo.AddRow(row, rownumber - 1);
                        row = new Fila();
                        rownumber++;
                        colnumber = 1;
                    }
                    else
                    {
                        colnumber++;
                    }
                }
                catch (FormatException exc)
                {
                    row.casillas[colnumber - 1] = new Casilla(0, rownumber, colnumber, supercellnumber);

                    if (colnumber == 9)
                    {
                        sudoSolver.sudo.AddRow(row, rownumber - 1);
                        row = new Fila();
                        rownumber++;
                        colnumber = 1;
                    }
                    else
                    {
                        colnumber++;
                    }
                }
            }            
        }
        private void ShowData()
        {
            int rownumber = 1;
            int colnumber = 1;

            foreach (TextBox Celda in Sudoku.Children)
            {
                if (sudoSolver.sudo.filas[rownumber-1].casillas[colnumber-1].Numero != 0)
                {
                    Celda.Text = sudoSolver.sudo.filas[rownumber-1].casillas[colnumber - 1].Numero.ToString();
                }
                else
                {
                    string posibles = "";
                    foreach (int posible in sudoSolver.sudo.filas[rownumber-1].casillas[colnumber - 1].Posibles)
                    {
                        if (posible != 0)
                        {
                            posibles = string.Concat(posibles, posible);
                        }
                    }
                    Celda.Text = posibles;
                }
                if (colnumber == 9)
                {
                    rownumber++;
                    colnumber = 1;
                }
                else
                {
                    colnumber++;
                }
            }           
        }
        private int DeterminateSupercell (int row, int col)
        {
            if ((row < 4) && (col < 4))
            {
               return 1;
            }
            else if ((row < 4) && (col > 3) && (col < 7))
            {
                return 2;
            }
            else if ((row < 4) && (col > 6))
            {
                return 3;
            }
            else if ((row > 3) && (row < 7) && (col < 4))
            {
                return 4;
            }
            else if ((row > 3) && (row < 7) && (col > 3) && (col < 7))
            {
                return 5;
            }
            else if ((row > 3) && (row < 7) && (col > 6))
            {
                return 6;
            }
            else if ((row > 6) && (col < 4))
            {
                return 7;
            }
            else if ((row > 6) && (col > 3) && (col < 7))
            {
                return 8;
            }
            else if ((row > 6) && (col > 6))
            {
                return 9;
            }else { return 0; }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox Celda in Sudoku.Children)
            {
                Celda.Text = "";
            }
        }
    }
}
