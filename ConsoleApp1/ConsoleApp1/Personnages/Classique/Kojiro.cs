using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Kojiro : Personnage
    {
        public Kojiro() : base()
        {
            pvMax = 5;
            nom = CstPersonnages.Kojiro;
            RecupererPdv();
        }

        public new bool peutAttaquer(Personnage p, int difficulteArme)
        {
            return true;
        }

        public bool peutAttaquer(Personnage p)
        {
            return true;
        }
    }
}
