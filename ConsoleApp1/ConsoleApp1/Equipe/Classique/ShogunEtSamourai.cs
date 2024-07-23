using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class ShogunEtSamourai : Equipe
    {

        public ShogunEtSamourai() : base()
        {
            this.nom = CstEquipes.ShogunEtSamourai;
        }

        public override void AjouterJoueurs(List<Joueur> joueurs)
        {
            foreach (Joueur joueur in joueurs)
            {
                if (joueur.GetRole() is Shogun || joueur.GetRole() is Samourai)
                {
                    this.joueurs.Add(joueur);
                    joueur.DonnerEquipe(this);
                }
                    
            }
        }
    }
}
