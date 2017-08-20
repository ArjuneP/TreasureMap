using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Utils
{
    public class Switch
    {
        public object Target { get; set; }
        public string Return { get; set; }

        public Switch(object target)
        {
            this.Target = target;
        }
    }
}
