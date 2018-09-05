using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    abstract class BaseStrategy
    {
        public BaseStrategy() { }

        public abstract Direction Act();

        class NullStrategy : BaseStrategy
        {
            public override Direction Act()
            {
                return Direction.NONE;
            }
        }
    }
}
