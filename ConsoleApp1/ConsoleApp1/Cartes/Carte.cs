using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public abstract class Carte
    {
        protected string nom;
        public Joueur? Possesseur;

        public string Nom { get => nom; }

        public abstract void Utiliser(Jeu j);

        public abstract void Utiliser(Jeu j, Joueur cible);
        public abstract void Utiliser(Jeu j, Joueur cible, int numCarte);
        public abstract void Utiliser(Jeu j, Joueur cible, int numCarte, bool estPermanente);
        public abstract void Defausser(List<Carte> defausse, List<Carte> deck);
    }
}
