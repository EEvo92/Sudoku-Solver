
namespace Sudoku_Solver.Models
{
    class Supercelda
    {
        public bool solucionado = false;
        public int Numero { get; set; }
        public Casilla[] casillas { get; set; }
        public Supercelda()
        {
            casillas = new Casilla[9];
        }

        public Supercelda(Supercelda sup)
        {
            this.solucionado = sup.solucionado;
            this.Numero = sup.Numero;
            this.casillas = sup.casillas;
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
