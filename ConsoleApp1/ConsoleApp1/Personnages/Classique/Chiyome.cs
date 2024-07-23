using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Chiyome : Personnage
    {
        public Chiyome() : base()
        {
            pvMax = 4;
            nom = CstPersonnages.Chiyome;
            RecupererPdv();
        }       

        public new void PerdPV(int dgt, bool atkDArme)
        {
            if(atkDArme == true)
                ModifierPv(-dgt);
            else
                Console.WriteLine("Dégâts annulés ! (Chiyome)");
        }
    }
}
