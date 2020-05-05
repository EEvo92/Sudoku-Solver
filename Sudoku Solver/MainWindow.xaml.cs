using Sudoku_Solver.ViewModels;
using Sudoku_Solver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku_Solver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            RepresentData();
        }

        private void AdquireData()
        {
            int casilla = 0;
            int row = 1;
            int col = 1;
            int supercell = 1;

            foreach (TextBox Celda in Sudoku.Children)
            {
               supercell = DeterminateSupercell(row, col);
                int Numero = 0;

                try
                {
                    Numero = Int32.Parse(Celda.Text);
                    if (Celda.Text.Equals(""))
                    {
                        sudoSolver.sudo.casillas[casilla] = new Casilla(0, row, col, supercell);
                    }
                    else
                    {
                        sudoSolver.sudo.casillas[casilla] = new Casilla(Numero, row, col, supercell);
                    }

                    if (col == 9)
                    {
                        row++;
                        col = 1;
                        casilla++;
                    }
                    else
                    {
                        col++;
                        casilla++;
                    } 
                }
                catch (FormatException exc)
                {
                    sudoSolver.sudo.casillas[casilla] = new Casilla(0, row, col, supercell);

                    if (col == 9)
                    {
                        row++;
                        col = 1;
                        casilla++;
                    }
                    else
                    {
                        col++;
                        casilla++;
                    }
                }
            }
        }

        private void RepresentData()
        {
            Celda11.Text = sudoSolver.sudo.casillas[0].Numero.ToString();
            Celda12.Text = sudoSolver.sudo.casillas[1].Numero.ToString();
            Celda13.Text = sudoSolver.sudo.casillas[2].Numero.ToString();
            Celda14.Text = sudoSolver.sudo.casillas[3].Numero.ToString();
            Celda15.Text = sudoSolver.sudo.casillas[4].Numero.ToString();
            Celda16.Text = sudoSolver.sudo.casillas[5].Numero.ToString();
            Celda17.Text = sudoSolver.sudo.casillas[6].Numero.ToString();
            Celda18.Text = sudoSolver.sudo.casillas[7].Numero.ToString();
            Celda19.Text = sudoSolver.sudo.casillas[8].Numero.ToString();
            Celda21.Text = sudoSolver.sudo.casillas[9].Numero.ToString();
            Celda22.Text = sudoSolver.sudo.casillas[10].Numero.ToString();
            Celda23.Text = sudoSolver.sudo.casillas[11].Numero.ToString();
            Celda24.Text = sudoSolver.sudo.casillas[12].Numero.ToString();
            Celda25.Text = sudoSolver.sudo.casillas[13].Numero.ToString();
            Celda26.Text = sudoSolver.sudo.casillas[14].Numero.ToString();
            Celda27.Text = sudoSolver.sudo.casillas[15].Numero.ToString();
            Celda28.Text = sudoSolver.sudo.casillas[16].Numero.ToString();
            Celda29.Text = sudoSolver.sudo.casillas[17].Numero.ToString();
            Celda31.Text = sudoSolver.sudo.casillas[18].Numero.ToString();
            Celda32.Text = sudoSolver.sudo.casillas[19].Numero.ToString();
            Celda33.Text = sudoSolver.sudo.casillas[20].Numero.ToString();
            Celda34.Text = sudoSolver.sudo.casillas[21].Numero.ToString();
            Celda35.Text = sudoSolver.sudo.casillas[22].Numero.ToString();
            Celda36.Text = sudoSolver.sudo.casillas[23].Numero.ToString();
            Celda37.Text = sudoSolver.sudo.casillas[24].Numero.ToString();
            Celda38.Text = sudoSolver.sudo.casillas[25].Numero.ToString();
            Celda39.Text = sudoSolver.sudo.casillas[26].Numero.ToString();
            Celda41.Text = sudoSolver.sudo.casillas[27].Numero.ToString();
            Celda42.Text = sudoSolver.sudo.casillas[28].Numero.ToString();
            Celda43.Text = sudoSolver.sudo.casillas[29].Numero.ToString();
            Celda44.Text = sudoSolver.sudo.casillas[30].Numero.ToString();
            Celda45.Text = sudoSolver.sudo.casillas[31].Numero.ToString();
            Celda46.Text = sudoSolver.sudo.casillas[32].Numero.ToString();
            Celda47.Text = sudoSolver.sudo.casillas[33].Numero.ToString();
            Celda48.Text = sudoSolver.sudo.casillas[34].Numero.ToString();
            Celda49.Text = sudoSolver.sudo.casillas[35].Numero.ToString();
            Celda51.Text = sudoSolver.sudo.casillas[36].Numero.ToString();
            Celda52.Text = sudoSolver.sudo.casillas[37].Numero.ToString();
            Celda53.Text = sudoSolver.sudo.casillas[38].Numero.ToString();
            Celda54.Text = sudoSolver.sudo.casillas[39].Numero.ToString();
            Celda55.Text = sudoSolver.sudo.casillas[40].Numero.ToString();
            Celda56.Text = sudoSolver.sudo.casillas[41].Numero.ToString();
            Celda57.Text = sudoSolver.sudo.casillas[42].Numero.ToString();
            Celda58.Text = sudoSolver.sudo.casillas[43].Numero.ToString();
            Celda59.Text = sudoSolver.sudo.casillas[44].Numero.ToString();
            Celda61.Text = sudoSolver.sudo.casillas[45].Numero.ToString();
            Celda62.Text = sudoSolver.sudo.casillas[46].Numero.ToString();
            Celda63.Text = sudoSolver.sudo.casillas[47].Numero.ToString();
            Celda64.Text = sudoSolver.sudo.casillas[48].Numero.ToString();
            Celda65.Text = sudoSolver.sudo.casillas[49].Numero.ToString();
            Celda66.Text = sudoSolver.sudo.casillas[50].Numero.ToString();
            Celda67.Text = sudoSolver.sudo.casillas[51].Numero.ToString();
            Celda68.Text = sudoSolver.sudo.casillas[52].Numero.ToString();
            Celda69.Text = sudoSolver.sudo.casillas[53].Numero.ToString();
            Celda71.Text = sudoSolver.sudo.casillas[54].Numero.ToString();
            Celda72.Text = sudoSolver.sudo.casillas[55].Numero.ToString();
            Celda73.Text = sudoSolver.sudo.casillas[56].Numero.ToString();
            Celda74.Text = sudoSolver.sudo.casillas[57].Numero.ToString();
            Celda75.Text = sudoSolver.sudo.casillas[58].Numero.ToString();
            Celda76.Text = sudoSolver.sudo.casillas[59].Numero.ToString();
            Celda77.Text = sudoSolver.sudo.casillas[60].Numero.ToString();
            Celda78.Text = sudoSolver.sudo.casillas[61].Numero.ToString();
            Celda79.Text = sudoSolver.sudo.casillas[62].Numero.ToString();
            Celda81.Text = sudoSolver.sudo.casillas[63].Numero.ToString();
            Celda82.Text = sudoSolver.sudo.casillas[64].Numero.ToString();
            Celda83.Text = sudoSolver.sudo.casillas[65].Numero.ToString();
            Celda84.Text = sudoSolver.sudo.casillas[66].Numero.ToString();
            Celda85.Text = sudoSolver.sudo.casillas[67].Numero.ToString();
            Celda86.Text = sudoSolver.sudo.casillas[68].Numero.ToString();
            Celda87.Text = sudoSolver.sudo.casillas[69].Numero.ToString();
            Celda88.Text = sudoSolver.sudo.casillas[70].Numero.ToString();
            Celda89.Text = sudoSolver.sudo.casillas[71].Numero.ToString();
            Celda91.Text = sudoSolver.sudo.casillas[72].Numero.ToString();
            Celda92.Text = sudoSolver.sudo.casillas[73].Numero.ToString();
            Celda93.Text = sudoSolver.sudo.casillas[74].Numero.ToString();
            Celda94.Text = sudoSolver.sudo.casillas[75].Numero.ToString();
            Celda95.Text = sudoSolver.sudo.casillas[76].Numero.ToString();
            Celda96.Text = sudoSolver.sudo.casillas[77].Numero.ToString();
            Celda97.Text = sudoSolver.sudo.casillas[78].Numero.ToString();
            Celda98.Text = sudoSolver.sudo.casillas[79].Numero.ToString();
            Celda99.Text = sudoSolver.sudo.casillas[80].Numero.ToString();
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
    }
}
