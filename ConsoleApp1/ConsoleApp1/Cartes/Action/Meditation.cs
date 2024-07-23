using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Meditation : CarteAction
    {

        public Meditation() : base()
        {
            nom = "Méditation";
        }


        public override void Utiliser(Jeu j, Joueur joueurCible)
        {
            Possesseur.RecupererPdv();
            joueurCible.Piocher(j.Pioche, 1);
            base.Defausser(j.Defausse, Possesseur.Deck);
        }



    }
}
