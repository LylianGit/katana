using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class CarteArme : Carte
    {
        protected int diff;
        protected int dgt;

        public CarteArme(string nom, int diff, int dgt) : base()
        {
            this.nom = nom;
            this.diff = diff;
            this.dgt = dgt;
        }

        public string GetNom()
        {
            return nom;
        }
        public int GetDgt()
        {
            return dgt;
        }

        public void Utiliser()
        {
            //if(PeutAtk(int dif))
            // p.EstAttaquer(dif);
        }

        public override void Utiliser(Jeu j)
        {

        }

        public override void Utiliser(Jeu j, Joueur joueurCible)
        {
            if (Possesseur.peutAttaquer(j.Joueurs.Count() ,joueurCible.Personnage.getPlacement(), diff))
            {
                Possesseur.Attaquer(joueurCible.Personnage, diff, dgt);
                //joueurCible.Piocher(j.Pioche, 1);
                Defausser(j.Defausse, Possesseur.Deck);
            }
            else
            {
                Console.WriteLine("Difficulté trop élevée pour attaquer ce joueur!");
            }
            
        }

        public override void Utiliser(Jeu j, Joueur cible, int numCarte) { }
        public override void Utiliser(Jeu j, Joueur cible, int numCarte, bool estPermanente) { }


        public override void Defausser(List<Carte> defausse, List<Carte> deck)
        {
            defausse.Add(this);
            deck.Remove(this);
            this.Possesseur = null;
        }

        public override string ToString()
        {
            return nom;
        }

    }
}
