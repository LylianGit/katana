using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class ERonin : Equipe
    {

        public ERonin() : base()
        {
            this.nom = CstEquipes.Ronin;
        }

        public override void AjouterJoueurs(List<Joueur> joueurs)
        {
            foreach (Joueur joueur in joueurs)
            {
                if (joueur.GetRole() is Ronin)
                {
                    this.joueurs.Add(joueur);
                    joueur.DonnerEquipe(this);
                }
                    
            }
        }
    }
}
