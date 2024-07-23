using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Nobunaga : Personnage
    {
        public Nobunaga() : base()
        {
            pvMax = 5;
            nom = CstPersonnages.Nobunaga;
            RecupererPdv();
        }

        public void ActiverCapacite(List<Carte> pioche)
        {
            if(pvMax > 1)
            {
                PerdPV(1, false, pioche);
                Piocher(pioche, 1);
            }
            else
            {
                Console.WriteLine("Vous devez posséder plus d'1 pvMax !");
            }
        }
    }
}
