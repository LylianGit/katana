using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    internal class Tomoe : Personnage
    {
        public Tomoe() : base()
        {
            pvMax = 5;
            nom = CstPersonnages.Tomoe;
            RecupererPdv();
        }


        //Capacité dans SeDefend() de la classe Personnage


        /*public void Attaquer(Personnage cible, int difficulteArme, int degatsArme)
        {
            if (peutAttaquer(cible, difficulteArme))
            {
                cible.SetEstAttaquer(degatsArme + degatsBonus);
            }
        }*/
    }
}
