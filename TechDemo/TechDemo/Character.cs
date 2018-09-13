using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    /// <summary>
    /// Classe abstraite qui représente un entité dans notre univers.
    /// </summary>
    abstract class Character : GameObject
    {
        protected bool isDead = false;

        public Character() { }
    }
}
