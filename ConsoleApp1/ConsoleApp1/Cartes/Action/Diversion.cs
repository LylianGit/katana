using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Diversion : CarteAction
    {

        public Diversion() : base()
        {
            nom = "Diversion";
        }


        public override void Utiliser(Jeu j, Joueur joueurCible, int numeroCarte)
        {
            Possesseur.Deck.Add(joueurCible.Deck.ElementAt(numeroCarte));
            Possesseur.Deck.Last().Possesseur = Possesseur;
            joueurCible.Deck.RemoveAt(numeroCarte);
            
            base.Defausser(j.Defausse, Possesseur.Deck);
        }



    }
}
