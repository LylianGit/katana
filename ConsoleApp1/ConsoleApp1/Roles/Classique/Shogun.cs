using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Shogun : Role 
    {
        public Shogun() : base()
        {
            this.nom = CstRoles.Shogun;
            nbPointDHonneur++;
            roi = true;
        }

        public Shogun(int multiplicateur) : base(multiplicateur)
        {
            this.nom = CstRoles.Shogun;
            nbPointDHonneur++;
            roi = true;
        }

    }
}
