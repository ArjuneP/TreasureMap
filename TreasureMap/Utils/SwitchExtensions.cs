using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap.Map;

namespace TreasureMap.Utils
{
    public static class SwitchExtensions
    {
        public static Switch Case<T>(this Switch @this, Action<T> action) where T : class
        {
            if (@this == null)
                return null;

            var t = @this.Target as T;
            if (t == null)
                return @this;

            action(t);
            return @this;
        }

        public static void Default(this Switch @this, Action action)
        {
            if (@this == null)
                return;

            action();
        }
    }
}
