using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Samourai : Role 
    {
        
        public Samourai() : base()
        {
            this.nom = CstRoles.Samourai;
        }

        public Samourai(int multiplicateur) : base(multiplicateur)
        {
            this.nom = CstRoles.Samourai;
        }

    }
}
