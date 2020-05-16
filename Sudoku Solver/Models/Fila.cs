
namespace Sudoku_Solver.Models
{
    class Fila
    {
        public bool solucionado = false;
        public int Numero { get; set; }
        public Casilla[] casillas { get; set; }

        public Fila()
        {
            casillas = new Casilla[9];
        }

        public Fila(Fila fil)
        {
            this.solucionado = fil.solucionado;
            this.Numero = fil.Numero;
            this.casillas = fil.casillas;
        }

        public void ChekIfSolved()
        {
            int cassolucionadas = 0;
            foreach (Casilla cas in casillas)
            {
                if (cas.solucionado == true)
                {
                    cassolucionadas++;
                }
            }

            if (cassolucionadas == 9)
            {
                solucionado = true;
            }
        }
    }
}
