using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Ninjas : Equipe
    {

        public Ninjas() : base()
        {
            this.nom = CstEquipes.Ninja;
        }

        public override void AjouterJoueurs(List<Joueur> joueurs)
        {
            foreach (Joueur joueur in joueurs)
            {

                if (joueur.GetRole() is Ninja)
                {
                    this.joueurs.Add(joueur);
                    joueur.DonnerEquipe(this);
                }
            }
        }

    }
}
