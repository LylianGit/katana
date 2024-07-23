using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public abstract class CarteAction : Carte
    {

        public CarteAction() : base()
        {
        }
        public CarteAction(string nom) : base()
        {
            this.nom = nom;
        }

        public override void Utiliser(Jeu j)
        {

        }
        public override void Utiliser(Jeu j, Joueur cible) { }
        public override void Utiliser(Jeu j, Joueur cible, int numCarte) { }
        public override void Utiliser(Jeu j, Joueur cible, int numCarte, bool estPermanente) { }
        public override void Defausser(List<Carte> defausse, List<Carte> deck)
        {
            defausse.Add(this);
            deck.Remove(this);
            this.Possesseur = null;
        }


    }
}
