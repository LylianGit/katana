using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Parade : CarteAction
    {

        public Parade() : base()
        {
            nom = "Parade";
        }

        public override void Utiliser(Jeu j)
        {
            if(Possesseur.Personnage.EstAttaquer > 0)
                base.Defausser(j.Defausse, Possesseur.Deck);
        }

    }
}
