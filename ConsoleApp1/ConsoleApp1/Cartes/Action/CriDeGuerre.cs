using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class CriDeGuerre : CarteAction
    {

        public CriDeGuerre() : base()
        {
            nom = "Cri de guerre";
        }


        public override void Utiliser(Jeu j)
        {
            foreach (Joueur joueur in j.Joueurs)
            {
                if (joueur == Possesseur)
                    ;
                else
                {
                    if (joueur.Choix != 0 && joueur.Deck.OfType<Parade>().Any())
                        joueur.Deck.Remove(joueur.Deck.OfType<Parade>().First());
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
//}
