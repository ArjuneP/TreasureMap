using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Map
{
    public interface IMapElement
    {
        int PosX { get; }
        int PosY { get; }

        MapElementType GetMapElementType();
    }
}
