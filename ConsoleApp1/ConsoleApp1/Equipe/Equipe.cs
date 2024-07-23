using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public abstract class Equipe 
    {
        protected string nom;
        protected int points;
        protected List<Joueur> joueurs;
        public Equipe()
        {
            nom = "";
            points = 0;
            joueurs = new List<Joueur>();
        }

        public void AjouterRole(Joueur joueur)
        {
            joueurs.Add(joueur);
        }
        public void AjouterPoints(int points)
        {
            this.points += points;
        }

        public int GetNbPoints()
        {
            if(points == 0)
            {
                foreach (Joueur joueur in joueurs)
                    points += joueur.GetRole().GetPointDHonneur();
            }
            return points;
        }

        public abstract void AjouterJoueurs(List<Joueur> joueurs);
    }
}
