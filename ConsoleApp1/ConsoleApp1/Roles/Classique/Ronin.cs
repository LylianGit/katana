using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Ronin : Role 
    {
        
        public Ronin() : base()
        {
            this.nom = CstRoles.Ronin;
        }

        public Ronin(int multiplicateur) : base(multiplicateur)
        {
            this.nom = CstRoles.Ronin;
        }
    }
}
