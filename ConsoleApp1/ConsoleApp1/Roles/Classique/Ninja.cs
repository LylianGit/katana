using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katana
{
    public class Ninja : Role 
    {
        
        public Ninja() : base()
        {
            this.nom = CstRoles.Ninja;
        }

        public Ninja(int multiplicateur) : base(multiplicateur)
        {
            this.nom = CstRoles.Ninja;
        }

        public override string ToString()
        {
            return nom;
        }
    }
}
