using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Jujitsu : CarteAction
    {


        public Jujitsu() : base()
        {
            nom = "Jujitsu";
        }

        public override void Utiliser(Jeu j)
        {
            foreach(Joueur joueur in j.Joueurs)
            {
                if (joueur == Possesseur)
                    ;
                else
                {
                    if (joueur.Choix != -1)
                        joueur.Deck.Remove(joueur.Deck[joueur.Choix]);
                    else
                        joueur.PerdPV(1);
                    
                    if (joueur.EstKO())
                        joueur.Role.DonnePointDHonneur(Possesseur);
                }
            }

            base.Defausser(j.Defausse, Possesseur.Deck);
        }

    }
}
