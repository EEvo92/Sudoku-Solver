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

        private void SolveRowButton_Click(object sender, RoutedEventArgs e)
        {
            AdquireData();
            sudoSolver.SolveRows();
            ShowData();
        }
        private void AdquireData()
        {
            int rownumber;
            int colnumber;
            int supercellnumber;
            int[] data;

            foreach (TextBox Celda in Cuadricula.Children)
            {
                data = GetLocationData(Celda);
                rownumber = data[0];
                colnumber = data[1];
                supercellnumber = data[2];
                int numero = 0;

                try
                {                
                    if (Celda.Text.Length == 1)
                    {
                        numero = Int32.Parse(Celda.Text);
                        sudoSolver.sudo.casillas [(rownumber-1)*9+(colnumber-1)] = new Casilla(numero, rownumber, colnumber, supercellnumber);
                    }
                    else
                    {
                        sudoSolver.sudo.casillas [(rownumber - 1) * 9 + (colnumber - 1)] = new Casilla(0, rownumber, colnumber, supercellnumber);
                    }
                }
                catch (FormatException exc)
                {
                    sudoSolver.sudo.casillas[(rownumber - 1) * 9 + (colnumber - 1)] = new Casilla(0, rownumber, colnumber, supercellnumber);
                }
            }            
        }

        private int[]  GetLocationData(TextBox textBox)
        {
            int[] data = new int[3];
            data[0] = Convert.ToInt16(textBox.Name[5].ToString());
            data[1] = Convert.ToInt16(textBox.Name[6].ToString());
            data[2] = Convert.ToInt16(textBox.Name[7].ToString());
            return data;
        }

        private void ShowData()
        {
            int rownumber = 1;
            int colnumber = 1;

            foreach (TextBox Celda in Cuadricula.Children)
            {
                if (sudoSolver.sudo.casillas[(rownumber - 1) * 9 + (colnumber - 1)].Numero != 0)
                {
                    Celda.Text = sudoSolver.sudo.casillas[(rownumber - 1) * 9 + (colnumber - 1)].Numero.ToString();
                }
                else
                {
                    string posibles = "";
                    foreach (int posible in sudoSolver.sudo.casillas[(rownumber - 1) * 9 + (colnumber - 1)].Posibles)
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

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox Celda in Cuadricula.Children)
            {
                Celda.Text = "";
            }
        }
    }
}
