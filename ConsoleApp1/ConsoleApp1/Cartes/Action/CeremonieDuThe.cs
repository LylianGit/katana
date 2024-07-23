using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class CeremonieDuThe : CarteAction
    {

        public CeremonieDuThe() : base()
        {
            nom = "Cérémonie du thé";
        }

        public override void Utiliser(Jeu j)
        {
            Possesseur.Piocher(j.Pioche, 3);
            foreach(Joueur joueur in j.Joueurs)
            {
                if (joueur == Possesseur) 
                    ;
                else
                    joueur.Piocher(j.Pioche, 1);
            }

            base.Defausser(j.Defausse, Possesseur.Deck);
        }

    }
}
