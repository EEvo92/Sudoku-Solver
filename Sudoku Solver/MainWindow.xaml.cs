using Sudoku_Solver.Models;
using Sudoku_Solver.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

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
            InitializeData();
            

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
            sudoSolver.Solve();
            sudoSolver.DeleteIndividualCandidates();
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
                        sudoSolver.sudo.Casillas [(rownumber-1)*9+(colnumber-1)] = new Casilla(numero, rownumber, colnumber, supercellnumber);
                    }
                    else
                    {
                        List<int> Posibles = new List<int>();
                        string texto = Celda.Text;
                        
                        for (int i = 0; i < texto.Length; i++)
                        {
                            Posibles.Add(Int32.Parse(texto.Substring(i,1)));
                        }
                        sudoSolver.sudo.Casillas [(rownumber - 1) * 9 + (colnumber - 1)] = new Casilla(0, rownumber, colnumber, supercellnumber);
                    }
                }
                catch (FormatException exc)
                {
                    sudoSolver.sudo.Casillas[(rownumber - 1) * 9 + (colnumber - 1)] = new Casilla(0, rownumber, colnumber, supercellnumber);
                }
            }            
        }
        private void InitializeData()
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
                sudoSolver.sudo.Casillas[(rownumber - 1) * 9 + (colnumber - 1)] = new Casilla(numero, rownumber, colnumber, supercellnumber);
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
            foreach (TextBox Celda in Cuadricula.Children)
            {
                int[] data; data = GetLocationData(Celda);
                int rownumber = data[0];
                int colnumber = data[1];
                int supercellnumber = data[2];

                if (sudoSolver.sudo.Casillas[(rownumber - 1) * 9 + (colnumber - 1)].Numero != 0)
                {
                    Celda.FontSize = 36;
                    Celda.TextAlignment = TextAlignment.Center;
                    //Celda.VerticalAlignment = VerticalAlignment.Center;
                    Celda.Text = sudoSolver.sudo.Casillas[(rownumber - 1) * 9 + (colnumber - 1)].Numero.ToString();
                    
                }
                else
                {
                    Celda.FontSize = 15;
                    Celda.TextAlignment = TextAlignment.Left;
                    string posibles = "";
                    foreach (int posible in sudoSolver.sudo.Casillas[(rownumber - 1) * 9 + (colnumber - 1)].Posibles)
                    {
                        if (posible != 0)
                        {
                            posibles = string.Concat(posibles, posible);
                        }
                    }
                    Celda.Text = posibles;
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
