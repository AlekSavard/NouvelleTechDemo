using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    /// <summary>
    /// Classe de strategies de base des ennemis
    /// </summary>
    abstract class BaseStrategy
    {
        public BaseStrategy() { }

        public abstract Direction Act();

        /// <summary>
        /// Classe null object de strategie des ennemis
        /// Cette classe retourne toujours un comportement vide, l'entité ne bouge plus. 
        /// </summary>
        public class NullStrategy : BaseStrategy
        {
            public NullStrategy() { }
            public override Direction Act()
            {
                return Direction.NONE;
            }
        }
    }
}
