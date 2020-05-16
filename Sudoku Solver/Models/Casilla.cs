using System.Linq;

namespace Sudoku_Solver.Models
{
    class Casilla
    {
        public bool solucionado;

        public int fila;

        public int columna;

        public int supercelda;
        public int Numero { get; set; }
        public int[] Posibles { get; set; }

        public int NumPosibles { get; set; }

        public Casilla(int num, int fil, int col, int sup)
        {
            if (num != 0)
            {
                NumPosibles = 0;
                solucionado = true;
            }
            else
            {
                NumPosibles = 9;
                solucionado = false;
            }

            Numero = num;
            Posibles = new int []{ 1, 2, 3, 4, 5, 6, 7, 8, 9};
            
            fila = fil;
            columna = col;
            supercelda = sup;
        }

        public Casilla( Casilla cas)
        {
            this.fila = cas.fila;
            this.columna = cas.columna;
            this.supercelda = cas.supercelda;
            this.solucionado = cas.solucionado;
            this.Numero = cas.Numero;
            this.NumPosibles = cas.NumPosibles;
            this.Posibles = cas.Posibles;
        }

        public void ChecIfSolved()
        {
            if (Numero == 0)
            {
                NumPosibles = 9;
                foreach (int i in Posibles)
                {
                    if ((i == 0) && (NumPosibles > 0))
                    {
                        NumPosibles--;
                    }
                }
                if (NumPosibles == 1)
                {
                    var linq = from item in this.Posibles where item != 0 select item;
                    this.Numero = linq.ElementAt(0);
                    this.solucionado = true;

                }
                if (solucionado)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        Posibles[i] = 0;
                    }
                }
            }
            else
            {
                solucionado = true;
            }
            
        }
    }
}
